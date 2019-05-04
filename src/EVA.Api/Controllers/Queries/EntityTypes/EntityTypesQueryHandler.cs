using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EVA.Application.Dto.EntityType;
using EVA.Infrastructure.Data.Abstractions.Context;
using MediatR;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EVA.Api.Controllers.Queries.EntityTypes
{
    public class EntityTypesQueryHandler : IRequestHandler<EntityTypesQuery, EntityTypesQueryResult>
    {
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public EntityTypesQueryHandler(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));            
        }

        public async Task<EntityTypesQueryResult> Handle(EntityTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await GetEntityTypes(cancellationToken);
            return new EntityTypesQueryResult(types);
        }

        private async Task<EntityTypeWithIdentityDto[]> GetEntityTypes(CancellationToken cancellationToken)
        {
            const string sql = @"select et.id, et.name, et.description 
                                 from entity_types et";

            using (var connection = new NpgsqlConnection(_dbSettings.Value.ConnectionString))
            {
                await connection.OpenAsync(cancellationToken);
                return ParseEntityTypes(await connection.QueryAsync<dynamic>(sql));
            }
        }

        private static EntityTypeWithIdentityDto[] ParseEntityTypes(IEnumerable<dynamic> data)
        {
            var attributes = new List<EntityTypeWithIdentityDto>();
            foreach (var item in data)
            {
                var attribute = new EntityTypeWithIdentityDto();
                attribute.Id = item.id;
                attribute.Name = item.name;                
                attribute.Description = item.description;
                attributes.Add(attribute);
            }
            return attributes.ToArray();
        }
    }
}