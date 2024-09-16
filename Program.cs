using lr2.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddXmlFile("companyInfo.xml", optional: false, reloadOnChange: true)
    .AddJsonFile("companyInfo.json", optional: false, reloadOnChange: true)
    .AddIniFile("companyInfo.ini", optional: false, reloadOnChange: true)
    .AddJsonFile("personInfo.json", optional: false, reloadOnChange: true);

builder.Services.AddScoped<CompanyAnalyzerService>();
builder.Services.AddScoped<PersonalInfoService>();

var app = builder.Build();

app.MapGet("/", (CompanyAnalyzerService analyzerService) =>
{
    return analyzerService.GetCompanyWithMostEmployees();
});

app.MapGet("/personInfo", async (HttpContext httpContext, PersonalInfoService personalInfoService) =>
{
    httpContext.Response.ContentType = "text/html; charset=utf-8";
    await httpContext.Response.WriteAsync(personalInfoService.GetPersonalInfo());
});

app.Run();