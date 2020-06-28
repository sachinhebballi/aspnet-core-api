using Api.Services.Models;
using FluentValidation;

namespace aspnet_core_api.Validators
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50).WithMessage("Please provide the first name");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50).WithMessage("Please provide the last name");

            RuleFor(x => x.Age).NotEmpty();
        }
    }
}
