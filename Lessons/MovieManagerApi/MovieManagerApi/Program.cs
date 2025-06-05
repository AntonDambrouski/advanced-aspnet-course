using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieManager.Core.Configurations;
using MovieManager.Core.Entities;
using MovieManager.Core.Interfaces;
using MovieManager.Core.Interfaces.Repositories;
using MovieManager.Core.Services;
using MovieManager.Core.Validations;
using MovieManager.Infrustructure;
using MovieManager.Infrustructure.Data;
using MovieManagerApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MoviesServiceConfig>(builder.Configuration.GetSection(nameof(MoviesServiceConfig)));
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<Movie>, MovieValidator>();

InfrustructureRegistrator.RegisterServices(builder.Services, builder.Configuration, builder.Environment.IsDevelopment());

var frontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? "https://localhost:5001";
builder.Services.AddCors(setup =>
{
    setup.AddPolicy("FrontendCors",
        policy => policy.WithOrigins(frontendUrl)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<MovieContext>();
        dbContext.Database.Migrate();
    }
}

app.UseHttpsRedirection();

app.UseCors("FrontendCors");

app.UseAuthorization();

// app.UseMiddleware<CustomMiddleware>();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
