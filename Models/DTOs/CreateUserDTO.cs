using System.ComponentModel.DataAnnotations.Schema;

namespace PetPals.Models.DTOs;

public class CreateUserDTO
{
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

    public CreateUserDTO(string lastName, string firstName, DateTime birthDate, Gender gender, string username, string tagname, string password, string email, string phoneNumber)
    {
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

    public UserModel ToUserModel()
    {
        return new UserModel(
            Username,
            Tagname,
            Email,
            PhoneNumber,
            Password,
            BirthDate,
            JoinDate,
            Gender,
            FirstName,
            LastName
        );
    }
}