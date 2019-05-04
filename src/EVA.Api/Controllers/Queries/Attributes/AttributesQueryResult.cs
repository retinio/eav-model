using EVA.Application.Dto.Attribute;
using EVA.Application.MediatR.Queries;

namespace EVA.Api.Controllers.Queries.Attributes
{
    public class AttributesQueryResult : QueryResult<AttributeWithIdentityDto[]>
    {
        public AttributesQueryResult(int statusCode, string[] errors) : base(statusCode, errors)
        {
        }

        public AttributesQueryResult(AttributeWithIdentityDto[] result) : base(result)
        {
        }
    }
}