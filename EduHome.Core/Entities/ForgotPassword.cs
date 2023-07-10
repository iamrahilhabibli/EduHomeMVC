using System.ComponentModel.DataAnnotations;

namespace EduHome.Core.Entities
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
