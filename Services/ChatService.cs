using PetPals.Models;

namespace PetPals.Services;

public class ChatService : IChatService
{
    private PetPalsContext _context;
    public ChatService(PetPalsContext context)
    {
        _context = context;
    }

    public async Task<List<MessageModel>> GetAllMessagesFromChatId(Guid id)
    {
        var allRooms = _context.ChatRoomModels.ToList();
        var room = allRooms.Find(room => room.Id.Equals(id));
        return room.Messages.ToList();
    }

    public async Task<List<UserModel>> GetAllParticipantsFromChatId(Guid id)
    {
        return _context.ChatRoomModels.ToList().Find(room => room.Id.Equals(id))?.Participants.ToList();
    }

    public async Task<UserModel> GetCreatorByChatId(Guid id)
    {
        return _context.ChatRoomModels.ToList().Find(room => room.Id.Equals(id)).CreatedBy;
    }
}