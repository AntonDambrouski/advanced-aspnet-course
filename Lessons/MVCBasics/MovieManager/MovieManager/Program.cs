using MovieManager;
using MovieManager.Services;
using MovieManager.Storages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddKeyedScoped<IMovieManagerService, MoviesManagerServiceMock>("mock");
//builder.Services.AddKeyedScoped<IMovieManagerService, MovieManagerService>("real");
//builder.Services.AddScoped<IReviewManagerService, ReviewManagerService>();
//builder.Services.AddScoped<IReviewsStorage, ReviewsStorage>();

//builder.Services.RegisterServices2();
ServiceRegistrator.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
