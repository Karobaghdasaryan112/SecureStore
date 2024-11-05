using SecureStore.API.Domain.Entities;
using SecureStore.API.DTOs.UserDTOs;

namespace SecureStore.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //Read
        Task<User> GetUserById(Guid Userid); 
        Task<User> GetUserByEmail(string Email);
        Task<User> GetUserByUsername(string Username);
        Task<User> GetUserByCustomer(Guid CustomerId);

        //Create
        Task<bool> UserLogin(UserLoginModel userLogin);
        Task UserRegistration(User user);

        //Update
    }
}
