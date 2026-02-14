using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite("Data Source=Movies.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MovieContext>();
    context.Database.EnsureCreated();

    if (!context.Categories.Any())
    {
        context.Categories.AddRange(
            new Category { CategoryName = "Action" },
            new Category { CategoryName = "Comedy" },
            new Category { CategoryName = "Drama" },
            new Category { CategoryName = "Horror" },
            new Category { CategoryName = "Sci-Fi" },
            new Category { CategoryName = "Family" }
        );
        context.SaveChanges();
    }
}


app.Run();
