using DaniilJobAggregator.Core.Interfaces;
using DaniilJobAggregator.Core.Interfaces.Repositories;
using DaniilJobAggregator.Core.Services;
using DaniilJobAggregator.Infrastructure.Data;
using DaniilJobAggregator.Infrastructure.Registrators;
using DaniilJobAggregator.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IvacancyService, VacancyService>();
builder.Services.AddScoped<IOrganisationService, OrganisationService>();

InfrastructureRegistrator.RegisterServices(builder.Services, 
                                            builder.Configuration, 
                                            builder.Environment.IsDevelopment());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
