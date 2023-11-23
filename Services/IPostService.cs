using PetPals.Models;

namespace PetPals.Services;

public interface IPostService
{
    Task<List<UserModel>> GetAllLikesFromPostId(Guid id);
    Task<List<UserModel>> GetAllSavesFromPostId(Guid id);
}