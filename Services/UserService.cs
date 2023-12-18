using Microsoft.CSharp.RuntimeBinder;
using PetPals.Models;
using PetPals.Models.DTOs;

namespace PetPals.Services;

public class UserService : IUserService
{
    private PetPalsContext _context;
    public UserService(PetPalsContext context)
    {
        _context = context;
    }

    public async Task<UserModel> GetUserById(Guid id)
    {
       return _context.UserModels.ToList().Find(user => user.Id.Equals(id));
    }

    public async Task<List<PostModel>> GetLikesByUserId(Guid id)
    {
        return _context.UserModels.ToList().Find(user => user.Id.Equals(id)).LikedPosts.ToList();
    }

    public async Task<List<NotificationModel>> GetNotificationsByUserId(Guid id)
    {
        return _context.NotificationModels.ToList().FindAll(n => n.Reciever.Id.Equals(id));
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return _context.UserModels.ToList();
    }

    public async Task<UserModel> CreateUser(CreateUserDTO newUser)
    {
        UserModel? foundUser =  await GetUserByEmail(newUser.Email);
        if (foundUser != null)
        {
            return null;
        }

        var changedUser = newUser.ToUserModel();
        
        _context.UserModels.Add(changedUser);
        await _context.SaveChangesAsync();
        return changedUser;
    }

    public async Task<UserModel> GetUserByEmail(string email)
    {
        return _context.UserModels.ToList().Find(user => user.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<UserModel> SignInUser(LoginCredentialsDTO creds)
    {
        var userByEmail =  await GetUserByEmail(creds.Email);
        if (userByEmail == null) throw new Exception();  //change this
        if (!userByEmail.Password.Equals(creds.Password)) throw new Exception(); //change also
        return userByEmail;
    }

    public Task<UserModel> UpdateUser(Guid id)
    {
        throw new NotImplementedException();
    }
}