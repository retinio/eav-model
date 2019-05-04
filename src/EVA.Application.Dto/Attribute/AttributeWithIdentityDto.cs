using System;
using Newtonsoft.Json;

namespace EVA.Application.Dto.Attribute
{
    public class AttributeWithIdentityDto : AttributeDto
    {
        [JsonRequired]
        public Guid Id { get; set; }
    }
}