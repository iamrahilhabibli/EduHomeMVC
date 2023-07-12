using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EduHome.Core.Entities
{
    public class GoogleCaptchaService
    {
        private ReCAPTCHASettings _settings { get; set; }

        public GoogleCaptchaService(IOptions<ReCAPTCHASettings> settings)
        {
            _settings = settings.Value;
        }
        public virtual async Task<GoogleREspo> VerifyCaptcha(string token)
        {
            GoogleCaptchaData data = new GoogleCaptchaData()
            {
                Response = token,
                Secret = _settings.ReCAPTCHA_Secret_Key
            };
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?=secret{data.Secret}&response={data.Response}");
            var capresp = JsonConvert.DeserializeObject<GoogleREspo>(response);
            return capresp;
        }
    }
}
