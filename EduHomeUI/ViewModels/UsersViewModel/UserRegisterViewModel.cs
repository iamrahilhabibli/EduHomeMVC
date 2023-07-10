using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.ViewModels.UsersViewModel
{
    public class UserRegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required,DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
