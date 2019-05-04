using EVA.Application.Dto.Attribute;
using EVA.Application.Dto.EntityType;
using FluentValidation;

namespace EVA.Api.Controllers.Commands.EntityTypes
{
    internal class EntityTypeValidator : AbstractValidator<EntityTypeDto>
    {        
        public EntityTypeValidator()
        {            
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Entity type name can't be empty.")
                .Matches(@"^[A-Za-z0-9-._]*$").WithMessage("Entity type name match only alphabets.")
                .MaximumLength(128).WithMessage("Max length of attribute name is 128 chars.");                   
        }
    }
}