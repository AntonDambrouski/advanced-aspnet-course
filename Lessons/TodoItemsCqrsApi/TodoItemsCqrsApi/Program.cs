using Microsoft.EntityFrameworkCore;
using TodoItemsCommands.Api.Producers;
using TodoItemsCqrsApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IEventProducer, EventProducer>();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseInMemoryDatabase("TodoDb"));

builder.Services.AddMediatR(cfg 
    => cfg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
