using System.Text;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Type = SecuritySchemeType.Http,
        Name = "Authorization",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddScoped<IValidator<Movie>, MovieValidator>();
builder.Services.AddScoped<ITokensService, TokensService>();

InfrustructureRegistrator.RegisterServices(builder.Services, builder.Configuration, builder.Environment.IsDevelopment());

builder.Services.AddMapster();

var frontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? "https://localhost:5001";
builder.Services.AddCors(setup =>
{
    setup.AddPolicy("FrontendCors",
        policy => policy.WithOrigins(frontendUrl)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
        );
});


var jwtConfig = builder.Configuration.GetSection(nameof(JwtConfiguration)).Get<JwtConfiguration>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(config =>
    {
        config.Audience = jwtConfig.Audience;
        config.RequireHttpsMetadata = false;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey)),
        };
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

app.UseAuthentication();
app.UseAuthorization();

// app.UseMiddleware<CustomMiddleware>();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();
