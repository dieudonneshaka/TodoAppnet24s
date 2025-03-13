using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add authentication and cookie-based authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Redirect to login if not authenticated
        options.AccessDeniedPath = "/Account/AccessDenied"; // Access denied page
    });

builder.Services.AddAuthorization();

builder.Services.AddRazorPages();

var app = builder.Build();

// Add authentication middleware to the pipeline
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
