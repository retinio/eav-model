using EVA.Application.Dto.EntityType;
using EVA.Application.MediatR.Queries;

namespace EVA.Api.Controllers.Queries.EntityTypes
{
    public class EntityTypesQueryResult : QueryResult<EntityTypeWithIdentityDto[]>
    {
        public EntityTypesQueryResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public EntityTypesQueryResult(EntityTypeWithIdentityDto[] result) : base(result)
        {
        }
    }
}