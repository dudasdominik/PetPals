using System.ComponentModel.DataAnnotations.Schema;

namespace PetPals.Models;
[Table("message")]
public class MessageModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public UserModel Sender { get; set; }
    public UserModel Recipient { get; set; }
    public string Body { get; set; }
    public DateTime TimeStamp { get; set; }
    public ICollection<PostModel> Photos { get; set; } = new List<PostModel>();
    public bool IsRead { get; set; } = false;
}