using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();
builder.Services.AddScoped<ConsumeService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SignalRContext>();


builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
	options.User.RequireUniqueEmail = false;
})
	.AddEntityFrameworkStores<SignalRContext>()
	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.AccessDeniedPath = "/Identity/AccessDenied";
	options.Cookie.Name = "YourAppCookieName";
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
	options.LoginPath = "/Login/Index";
	options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
	options.SlidingExpiration = true;
});


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

using (var scope = app.Services.CreateScope())
{
	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
	var dbContext = scope.ServiceProvider.GetRequiredService<SignalRContext>();

	if (userManager.FindByEmailAsync("admin@example.com").Result == null)
	{
		var user = new AppUser
		{
			UserName = "admin",
			Email = "admin@example.com"
		};

		var result = userManager.CreateAsync(user, "Password123*!").Result;
		if (result.Succeeded)
		{
			
		}
	}
}



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
