using FluentValidation;

namespace EVA.Api.Controllers.Commands.Attributes.Update
{
    public class UpdateAttributeCommandValidation : AbstractValidator<UpdateAttributeCommand>
    {
        public UpdateAttributeCommandValidation()
        {
            RuleFor(c => c.Attribute)
                .NotNull().WithMessage("Attribute can't be null.")
                .SetValidator(new AttributeValidator());
        }
    }
}