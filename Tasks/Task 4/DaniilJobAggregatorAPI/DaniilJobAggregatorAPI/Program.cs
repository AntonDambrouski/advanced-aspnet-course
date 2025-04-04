using DaniilJobAggregator.DAL.Repositories.Implementations;
using DaniilJobAggregator.DAL.Repositories.Interfaces;
using DaniilJobAggregator.Services.Implementations;
using DaniilJobAggregator.Services.Interfaces;
using DaniilJobAggregatorAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVacancyRepository, VacancyRepository>();
builder.Services.AddScoped<IOrganisationRepository, OrganisationRepository>();
builder.Services.AddScoped<IvacancyService, VacancyService>();
builder.Services.AddScoped<IOrganisationService, OrganisationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseToken("test_token");
//app.UseMiddleware<TokenMiddleware>();

app.MapControllers();

app.Run();
