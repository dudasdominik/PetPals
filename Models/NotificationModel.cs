using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace PetPals.Models;
[Table("notification")]
public class NotificationModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public NotificationType NotificationType { get; set; }
    public UserModel Sender { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Body { get; set; }
    public string LinkToItem { get; set; }
    public bool IsRead { get; set; } = false;
}