using Microsoft.EntityFrameworkCore;
using SecureStore.API.AppDbContext;
using SecureStore.API.Domain.Entities;
using SecureStore.API.DTOs.UserDTOs;
using SecureStore.API.Repositories.Interfaces;

namespace SecureStore.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context { get; set; }
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task<User> IUserRepository.GetUserById(Guid Userid)
        {
            User user = await _context.Users.FirstOrDefaultAsync(User => User.Id == Userid);
            return user;
        }

        async Task<User> IUserRepository.GetUserByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        async Task<User> IUserRepository.GetUserByUsername(string Username)
        {
            User user = await _context.Users.FirstOrDefaultAsync(User => User.UserName == Username);
            return user;
        }

        Task<User> IUserRepository.GetUserByCustomer(Guid CustomerId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.UserLogin(UserLoginModel userLogin)
        {
            throw new NotImplementedException();
        }

        async Task IUserRepository.UserRegistration(User userRegistration)
        {
            await _context.Users.AddAsync(userRegistration);
            await _context.SaveChangesAsync();
        }
    }
}
