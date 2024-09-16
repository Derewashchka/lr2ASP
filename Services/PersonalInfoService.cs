using Microsoft.Extensions.Configuration;
using System.Text;

namespace lr2.Services
{
    public class PersonalInfoService
    {
        private readonly IConfiguration _configuration;

        public PersonalInfoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetPersonalInfo()
        {
            var name = _configuration["PersonalInfo:Name"];
            var age = _configuration["PersonalInfo:Age"];
            var dateOfBirth = _configuration["PersonalInfo:DateOfBirth"];

            var sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang='uk'>");
            sb.Append("<head>");
            sb.Append("<meta charset='utf-8'>");
            sb.Append("<title>Особиста інформація</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<h1>Особиста інформація</h1>");
            sb.AppendFormat("<p>Ім'я: {0}</p>", name);
            sb.AppendFormat("<p>Вік: {0}</p>", age);
            sb.AppendFormat("<p>Дата народження: {0}</p>", dateOfBirth);
            sb.Append("</body>");
            sb.Append("</html>");

            return sb.ToString();
        }
    }
}