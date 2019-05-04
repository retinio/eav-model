using FluentValidation;

namespace EVA.Api.Controllers.Commands.Attributes.Create
{
    public class CreateAttributeCommandValidation : AbstractValidator<CreateAttributeCommand>
    {
        public CreateAttributeCommandValidation()
        {
            RuleFor(c => c.Attribute)
                .NotNull().WithMessage("Attrubute can't be null.")
                .SetValidator(new AttributeValidator());
        }
    }
}