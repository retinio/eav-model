using System;
using Newtonsoft.Json;

namespace EVA.Application.Dto.EntityType
{
    public class EntityTypeWithIdentityDto : EntityTypeDto
    {
        [JsonRequired]
        public Guid Id { get; set; }
    }
}