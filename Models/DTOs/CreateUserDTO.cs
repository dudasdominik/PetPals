using System.ComponentModel.DataAnnotations.Schema;

namespace PetPals.Models.DTOs;

public class CreateUserDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Username { get; set; }
    public string Tagname { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.Now.ToUniversalTime();

    public CreateUserDTO(Guid id, string lastName, string firstName, DateTime birthDate, Gender gender, string username, string tagname, string password, string email, string phoneNumber)
    {
        
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        BirthDate = birthDate;
        Gender = gender;
        Username = username;
        Tagname = tagname;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public static implicit operator UserModel(CreateUserDTO user)
    {
        return new UserModel(user.Id, user.Username, user.Tagname, user.Email, user.PhoneNumber, user.Password, user.BirthDate, user.JoinDate, user.Gender, user.FirstName, user.LastName);
    }
}