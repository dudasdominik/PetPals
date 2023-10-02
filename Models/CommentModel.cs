using System.ComponentModel.DataAnnotations.Schema;

namespace PetPals.Models;
[Table("comment")]
public class CommentModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Body { get; set; }
    public UserModel Sender { get; set; }
    public DateTime TimeStamp { get; set; }
    public PostModel ToPost { get; set; }
    public Guid ParentCommentId { get; set; }
    public ICollection<CommentModel> Replies { get; set; } = new List<CommentModel>();
    public bool IsReplyTo { get; set; } = false;
}