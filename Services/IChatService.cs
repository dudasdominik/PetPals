using PetPals.Models;

namespace PetPals.Services;

public interface IChatService
{
    Task<List<MessageModel>> GetAllMessagesFromChatId(Guid id);
    Task<List<UserModel>> GetAllParticipantsFromChatId(Guid id);
    Task<UserModel> GetCreatorByChatId(Guid id);
}