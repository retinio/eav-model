using System;

namespace EVA.Application.Dto.Entities
{
    public class EntityWithIdentityDto : EntityDto
    {
        public Guid Id { get; set; }
    }
}