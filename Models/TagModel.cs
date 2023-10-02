using System.ComponentModel.DataAnnotations.Schema;

namespace PetPals.Models;
public class TagModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string TagName { get; set; }
    public ICollection<PostTagModel> PostTags { get; set; } = new List<PostTagModel>();
}