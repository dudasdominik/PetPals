namespace PetPals.Models;

public class PostTagModel
{
    public Guid PostId { get; set; }
    public PostModel Post { get; set; }

    public Guid TagId { get; set; }
    public TagModel Tag { get; set; }
}