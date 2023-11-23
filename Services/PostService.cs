using PetPals.Models;

namespace PetPals.Services;

public class PostService : IPostService
{
    private PetPalsContext _context;
    public PostService(PetPalsContext context)
    {
        _context = context;
    }

    public async Task<List<UserModel>> GetAllLikesFromPostId(Guid id)
    {
        return _context.PostModels.ToList().Find(post => post.Id.Equals(id)).Likes.ToList();
    }

    public async Task<List<UserModel>> GetAllSavesFromPostId(Guid id)
    {
        return _context.PostModels.ToList().Find(post => post.Id.Equals(id)).Saves.ToList();
    }
}