using FluentValidation;
using SecureStore.API.DTOs.UserDTOs;
namespace SecureStore.API.Validation.UserValidation
{


    public class UserRegistrationValidator : AbstractValidator<UserRegistrationModel>
    {
        public UserRegistrationValidator()
        {

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty.")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters long.");


            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name cannot be empty.")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.");


            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.");


            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");


            RuleFor(user => user.ConfirmPassword)
                .NotEmpty().WithMessage("Please confirm your password.")
                .Equal(user => user.Password).WithMessage("Passwords do not match.");
        }
    }

}
