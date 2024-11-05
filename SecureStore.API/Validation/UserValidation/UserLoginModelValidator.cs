using FluentValidation;
using SecureStore.API.DTOs.UserDTOs;

namespace SecureStore.API.Validation.UserValidation
{
    public class UserLoginModelValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginModelValidator()
        {
            // Проверка, что Id не является пустым значением
            RuleFor(user => user.UserName)
                .NotEmpty()
                .WithMessage("UserName Cannot be Empty");

            // Проверка, что пароль не пустой и имеет минимальную длину
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("password Cannot be Empty")
                .MinimumLength(6)
                .WithMessage("minimum length is 6");
        }
    }

}
