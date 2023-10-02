using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace PetPals.Models;
[Table("user")]
public class UserModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string TagName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }

    public DateTime JoinDate { get; set; } = DateTime.Now;
    
    public PhotoModel ProfilePicture { get; set; }
    
    public PhotoModel BannerPicture { get; set; }

    public ICollection<PostModel> OwnPosts { get; set; } = new List<PostModel>();
    
    public ICollection<PostModel> SavedPosts { get; set; } = new List<PostModel>();
    
    public ICollection<PostModel> LikedPosts { get; set; } = new List<PostModel>();
    
    public ICollection<UserModel> Followers { get; set; } = new List<UserModel>();
    
    public ICollection<UserModel> Followings { get; set; } = new List<UserModel>();
    
    public string Location { get; set; }
    
    public string Bio { get; set; }
    
    public string Role { get; set; }

    public bool isVerified { get; set; } = false;
    
    public DateTime LastLoginDate { get; set; }
    [Required]
    public Gender Gender { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
}