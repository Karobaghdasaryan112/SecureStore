using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SecureStore.API.AppDbContext;
using SecureStore.API.AppDbContext.Security;
using SecureStore.API.Repositories.Implementations;
using SecureStore.API.Repositories.Interfaces;
using SecureStore.API.Services.Impelemntations;
using SecureStore.API.Services.Interfaces;
using SecureStore.API.Validation.UserValidation;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(Option => Option.UseSqlServer(ConnectionString));
builder.Services.AddTransient<IPasswordHasher,PasswordHasher>();
builder.Services.AddSingleton<UserLoginModelValidator>();
builder.Services.AddSingleton<UserRegistrationValidator>();
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<ILineItemRepository,LineItemRepository>();
builder.Services.AddTransient<IOrderRepository,OrderRepository>();


builder.Services.AddTransient<IOrderService,OrderService>();
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddTransient<ILineItemService,LineItemService>();
builder.Services.AddTransient<IUserService,UserService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
