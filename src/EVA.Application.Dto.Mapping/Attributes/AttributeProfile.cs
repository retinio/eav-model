using System;
using System.Reflection;
using AutoMapper;
using EVA.Application.Dto.Attribute;
using EVA.Application.Dto.Entities;
using EVA.Domain.Entities;

namespace EVA.Application.Dto.Mapping.Attributes
{
    public class AttributeProfile : Profile
    {
        public AttributeProfile()
        {
            CreateMap<Domain.Attributes.Attribute, AttributeWithIdentityDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(o => o.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(new AttributeResolver()));
        }
    }

    internal class AttributeResolver : IValueResolver<Domain.Attributes.Attribute, AttributeWithIdentityDto, AttributeTypeDto>
    {
        public AttributeTypeDto Resolve(Domain.Attributes.Attribute source, AttributeWithIdentityDto destination, AttributeTypeDto destMember,
            ResolutionContext context)
        {
            var typeId = GetAttributeTypeId(source);
            var type = Domain.Attributes.AttributeType.FromId(typeId);
            return (AttributeTypeDto)Enum.Parse(typeof(AttributeTypeDto), type.Name, true);
        }

        private static int GetAttributeTypeId(Domain.Attributes.Attribute attribute)
        {
            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = typeof(Domain.Attributes.Attribute).GetField("_typeId", bindFlags);
            return (int)field.GetValue(attribute);
        }
    }
}