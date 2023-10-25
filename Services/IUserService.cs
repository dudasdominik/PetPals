using PetPals.Models;
using PetPals.Models.DTOs;

namespace PetPals.Services;

public interface IUserService
{
    Task<UserModel> GetUserById(Guid id);
    Task<List<PostModel>> GetLikesByUserId(Guid id);
    Task<List<NotificationModel>> GetNotificationsByUserId(Guid id);
    Task<List<UserModel>> GetAllUsers();
    Task<UserModel> CreateUser(CreateUserDTO newUser);
    Task<UserModel> GetUserByEmail(string email);
    Task<UserModel> SignInUser(LoginCredentialsDTO creds);
    Task<UserModel> UpdateUser(Guid id);
}