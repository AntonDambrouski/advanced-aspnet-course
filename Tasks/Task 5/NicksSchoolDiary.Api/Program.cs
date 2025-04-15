using NicksSchoolDiary.Api.Filters;
using NicksSchoolDiary.Api.Middleware;
using NicksSchoolDiary.Domain.Services;
using NicksSchoolDiary.Domain.Interfaces;
using NicksSchoolDiary.DAL.Registrators;
using System.Text.Json.Serialization;
using FluentValidation;
using NicksSchoolDiary.Domain.Models;
using NicksSchoolDiary.Domain.Validation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DALRegistrator.RegisterService(builder.Services, builder.Configuration, builder.Environment.IsDevelopment());

builder.Services.AddScoped<IValidator<Student>, StudentValidator>();
builder.Services.AddScoped<IValidator<StudentClass>, StudentClassValidator>();


builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentClassService, StudentClassService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0);
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCheckUserAgent("Firefox");
app.UseCustomExceptionHandler();
app.MapControllers();

app.Run();
