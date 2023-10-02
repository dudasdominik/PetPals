using System.ComponentModel.DataAnnotations.Schema;

namespace PetPals.Models;

[Table("chatroom")]
public class ChatRoomModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserModel> Participants { get; set; } = new List<UserModel>();
    public ICollection<MessageModel> Messages { get; set; } = new List<MessageModel>();
    public bool IsPublic { get; set; }
    public UserModel CreatedBy { get; set; }
    
}