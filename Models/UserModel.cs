using System.ComponentModel.DataAnnotations;
namespace csapi.Models
{
    public record UserInput(
        string Name,
        string UserName,
        string Email,
        string Bio,
        string BirthDate,
        string Gender,
        string Avatar,
        string Header,
        string Password
    );

    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public string Header { get; set; }
        public string Password { get; set; }
    }
}