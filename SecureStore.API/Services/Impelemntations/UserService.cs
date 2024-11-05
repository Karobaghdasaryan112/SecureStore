using SecureStore.API.AppDbContext.Security;
using SecureStore.API.Domain.Entities;
using SecureStore.API.DTOs.UserDTOs;
using SecureStore.API.Repositories.Interfaces;
using SecureStore.API.Services.Interfaces;
using SecureStore.API.Validation.UserValidation;

namespace SecureStore.API.Services.Impelemntations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        private IPasswordHasher _passwordHasher { get; set; }
        private UserLoginModelValidator _loginvalidationRules { get; set; }
        private UserRegistrationValidator _registrationValidationRules { get; set; }
        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            UserLoginModelValidator loginvalidationRules,
            UserRegistrationValidator registrationValidationRules
            )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _loginvalidationRules = loginvalidationRules;
            _registrationValidationRules = registrationValidationRules;
        }

        async Task<UserProfileModel> IUserService.UserLogin(UserLoginModel userLogin)
        {
            var validationResult = _loginvalidationRules.Validate(userLogin);

            if (validationResult.IsValid)
            {
                var user = await _userRepository.GetUserByUsername(userLogin.UserName);
                if (user == null)
                {
                    throw new InvalidOperationException("User not found.");
                }

                if (_passwordHasher.VerifyPassword(userLogin.Password, user.Password))
                {
                    return new UserProfileModel()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                }
                else
                {
                    throw new UnauthorizedAccessException("Invalid password.");
                }
            }
            else
            {
                throw new InvalidOperationException("Validation failed for the provided login model.");
            }
        }

        async Task IUserService.UserRegistration(UserRegistrationModel userRegistration)
        {
            var validationResult = _registrationValidationRules.Validate(userRegistration);

            if (!validationResult.IsValid)
                throw new ArgumentException("Validation failed for the provided registration data.");

            var existingUser = _userRepository.GetUserByUsername(userRegistration.UserName);

            if (existingUser != null)
                throw new InvalidOperationException("A user with the given username already exists.");

            string passwordHash = _passwordHasher.GetHashPassword(userRegistration.Password);

            User user = new User()
            {
                CreatedAt = DateTime.UtcNow,
                Email = userRegistration.Email,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                Password = passwordHash,
                UserName = userRegistration.UserName,
                Id = Guid.NewGuid()
            };

           await _userRepository.UserRegistration(user);
        }
        Task IUserService.EditProfile(UserProfileModel OldIserProfile, UserProfileModel NewUserProfile)
        {
            throw new NotImplementedException();
        }

        async Task<User> IUserService.GetUserByUserName(string userName)
        {
            return await _userRepository.GetUserByUsername(userName);
        }
    }
}
