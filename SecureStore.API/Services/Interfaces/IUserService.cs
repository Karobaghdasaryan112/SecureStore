using SecureStore.API.Domain.Entities;
using SecureStore.API.DTOs.UserDTOs;

namespace SecureStore.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileModel> UserLogin(UserLoginModel userLogin);
        Task UserRegistration(UserRegistrationModel userRegistration);
        Task EditProfile(UserProfileModel OldIserProfile,UserProfileModel NewUserProfile);
        Task<User> GetUserByUserName(string userName);  
    }
}
