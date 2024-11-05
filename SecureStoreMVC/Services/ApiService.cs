using SecureStore.API.Domain.Entities;
using SecureStore.API.DTOs.UserDTOs;
using SecureStore.MVC.UserDTOs;
namespace SecureStore.MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserProfileModel> UserLogin(UserLoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7052/api/User/Login", loginModel);
            if (response.IsSuccessStatusCode)
            {
                var Result = await response.Content.ReadAsAsync<UserProfileModel>();
                return Result;
            }
            throw new HttpRequestException();
        }
        public async Task UserRegistration(UserRegistrationModel userRegistration)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7052/api/User/Registration", userRegistration);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            throw new HttpRequestException();
        }
        public async Task<ICollection<ProductModel>> GetAllProducts()
        {
            var response = await _httpClient.GetAsync("https://localhost:7052/api/Product/Products");
            if (response.IsSuccessStatusCode)
            {
                var Result = await response.Content.ReadAsAsync<ICollection<ProductModel>>();
                return Result;
            }
            throw new HttpRequestException();
        }
        public async Task<List<Order>> GetOrderByUser(string UserName)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7052/api/Order/Orders/{UserName}");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();

                Console.WriteLine(errorMessage);
            }

            var Result = await response.Content.ReadAsAsync<List<Order>>();
            return Result;
        }
    }
}
