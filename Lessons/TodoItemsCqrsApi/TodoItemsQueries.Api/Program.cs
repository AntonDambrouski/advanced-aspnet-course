using TodoItemsQueries.Api.Consumers;
using TodoItemsQueries.Api.Data;
using TodoItemsQueries.Api.EventHandlers;
using TodoItemsQueries.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHostedService<ConsumerBackgroundService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMediatR(cfg
    => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddScoped<IEventConsumer, EventConsumer>();
builder.Services.AddScoped<IEventHandlerDispatcher, EventHandlerDispatcher>();
builder.Services.AddScoped<IDictionaryDatabase, DictionaryDatabase>();
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
