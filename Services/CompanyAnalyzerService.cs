using Microsoft.Extensions.Configuration;

namespace lr2.Services
{
    public class CompanyAnalyzerService
    {
        private readonly IConfiguration _configuration;

        public CompanyAnalyzerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetCompanyWithMostEmployees()
        {
            var companies = new[]
            {
                ("Microsoft", _configuration.GetValue<int>("Companies:0:EmployeeCount")),
                ("Apple", _configuration.GetValue<int>("Companies:1:EmployeeCount")),
                ("Google", _configuration.GetValue<int>("Companies:2:EmployeeCount"))
            };

            var companyWithMostEmployees = companies.OrderByDescending(c => c.Item2).First();

            return $"Компанія з найбільшою кількістю співробітників: {companyWithMostEmployees.Item1} ({companyWithMostEmployees.Item2} співробітників)";
        }
    }
}