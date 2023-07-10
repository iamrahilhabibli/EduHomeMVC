using System.ComponentModel.DataAnnotations;

namespace EduHomeUI.ViewModels.CaptchaViewModel
{
	public class CaptchaViewModel
	{
		[Required]
        public string Captcha { get; set; }
    }
}
