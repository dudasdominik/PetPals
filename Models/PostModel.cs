using System.ComponentModel.DataAnnotations.Schema;

namespace PetPals.Models;
[Table("post")]
public class PostModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public UserModel Sender { get; set; }
    public Guid SenderId { get; set; }
    public string Title { get; set; }
    public ICollection<PostTagModel> Tags { get; set; } = new List<PostTagModel>();
    public string Body { get; set; }
    public ICollection<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
    public DateTime TimeStamp { get; set; }
    public ICollection<UserModel> Likes { get; set; } = new List<UserModel>();
    public ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();
    public ICollection<UserModel> Saves { get; set; } = new List<UserModel>();
    public int Views { get; set; }
}