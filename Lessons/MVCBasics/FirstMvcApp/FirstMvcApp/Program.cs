var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapAreaControllerRoute("areaStuff",
    areaName: "Stuff",
    pattern: "Stuff/{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(name: "products",
//    pattern: "goods/{*any}",
//    defaults: new { controller = "Products", action = "Any" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();

Convert.ToInt32("100", fromBase: 2);

new string[] {"a", "b"}.Aggregate(string.Empty, (acc, x) => acc + x);