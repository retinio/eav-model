using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EVA.Application.Dto.Attribute;
using EVA.Infrastructure.Data.Abstractions.Context;
using MediatR;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EVA.Api.Controllers.Queries.Attributes
{
    public class AttributesQueryHandler : IRequestHandler<AttributesQuery, AttributesQueryResult>
    {
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public AttributesQueryHandler(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));
        }

        public async Task<AttributesQueryResult> Handle(AttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await GetAttributes(cancellationToken);
            return new AttributesQueryResult(attributes);
        }

        private async Task<AttributeWithIdentityDto[]> GetAttributes(CancellationToken cancellationToken)
        {
            const string sql = @"select a.id, t.name as type, a.name, a.description
                                 from attributes a
                                 inner join attribute_types t on t.id = a.type_id";

            using (var connection = new NpgsqlConnection(_dbSettings.Value.ConnectionString))
            {
                await connection.OpenAsync(cancellationToken);
                return ParseAttributes(await connection.QueryAsync<dynamic>(sql));
            }
        }

        private static AttributeWithIdentityDto[] ParseAttributes(IEnumerable<dynamic> data)
        {
            var attributes = new List<AttributeWithIdentityDto>();
            foreach (var item in data)
            {
                var attribute = new AttributeWithIdentityDto();
                attribute.Id = item.id;
                attribute.Name = item.name;
                attribute.Type = Enum.Parse(typeof(AttributeTypeDto), item.type, true);
                attribute.Description = item.description;                
                attributes.Add(attribute);
            }
            return attributes.ToArray();
        }
    }
}