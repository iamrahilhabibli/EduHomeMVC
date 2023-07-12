using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.ViewModels.UsersViewModel
{
    public class UserLoginViewModel
    {
        [Required,DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = null!;
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }=null!;
        public bool RememberMe { get; set; }
    }
}
