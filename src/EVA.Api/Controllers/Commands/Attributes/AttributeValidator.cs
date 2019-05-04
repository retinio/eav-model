using EVA.Application.Dto.Attribute;
using FluentValidation;

namespace EVA.Api.Controllers.Commands.Attributes
{
    internal class AttributeValidator : AbstractValidator<AttributeWithOutTypeDto>
    {        
        public AttributeValidator()
        {            
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Attribute name can't be emty.")
                .Matches(@"^[A-Za-z0-9-._]*$").WithMessage("Attribute name match only alphabets.")
                .MaximumLength(128).WithMessage("Max length of attribute name is 128 chars.");                   
        }
    }
}