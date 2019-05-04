using EVA.Api.Controllers.Commands.Attributes;
using FluentValidation;

namespace EVA.Api.Controllers.Commands.EntityTypes.Create
{
    public class CreateEntityTypeCommandValidation : AbstractValidator<CreateEntityTypeCommand>
    {
        public CreateEntityTypeCommandValidation()
        {
            RuleFor(c => c.Entity)
                .NotNull().WithMessage("Entity can't be null.")
                .SetValidator(new EntityTypeValidator());
        }
    }
}