//using _2_4AurorasBricks2.Data;

using _2_4AurorasBricks2.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


// Retrieve the connection strings from environment variables
var connectionStringIntex2Security = Environment.GetEnvironmentVariable("Intex2Security")
    ?? builder.Configuration.GetConnectionString("Intex2Security");
var connectionStringLego = Environment.GetEnvironmentVariable("Lego")
    ?? builder.Configuration.GetConnectionString("Lego");

// Retrieve the email password from an environment variable
var emailPassword = Environment.GetEnvironmentVariable("EmailPassword");

// Setup services with connection strings from Key Vault
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LoginDbContext>(options =>
{
    options.UseSqlServer(connectionStringIntex2Security); // Use the connection string retrieved from Key Vault
});

builder.Services.AddDbContext<LegoContext>(options =>
{
    options.UseSqlServer(connectionStringLego); // Use the connection string retrieved from Key Vault
});
builder.Services.AddTransient<ISenderEmail, EmailSender>();
builder.Services.AddSingleton<IEmailConfiguration>(new EmailConfiguration
{
    MailServer = builder.Configuration["EmailSettings:MailServer"],
    MailPort = int.Parse(builder.Configuration["EmailSettings:MailPort"]),
    SenderName = builder.Configuration["EmailSettings:SenderName"],
    FromEmail = builder.Configuration["EmailSettings:FromEmail"],
    Password = emailPassword // Ensure this is the password from the environment variable
});

// Google Authenticator
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["GoogleClientId"];
    googleOptions.ClientSecret = builder.Configuration["GoogleClientSecret"];
});




builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredUniqueChars = 4;
        // Other settings can be configured here

    })
    .AddEntityFrameworkStores<LoginDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ISenderEmail, EmailSender>();

// Configure the Application Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    // If the LoginPath isn't set, ASP.NET Core defaults the path to /Account/Login.
    options.LoginPath = "/Account/Login"; // Set your login path here
    options.AccessDeniedPath = "/Account/InsufficientPrivileges"; // Set the path to the page for insufficient privileges
});

// Configure token lifespan
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    // Set token lifespan to 2 hours
    options.TokenLifespan = TimeSpan.FromHours(2);
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<ILegoRepository, EFLegoRepository>();

builder.Services.AddRazorPages();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential 
    // cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;

    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookieValue = "true";
});

// Configure HSTS to use a longer max age, include subdomains, and enable preloading
builder.Services.AddHsts(options =>
{
    options.MaxAge = TimeSpan.FromDays(365);
    options.IncludeSubDomains = true;
    options.Preload = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

var app = builder.Build();

//enable CSP Header
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "base-uri 'self'; " + "default -src 'self'; " +
        "img-src 'self' https://m.media-amazon.com https://www.lego.com https://images.brickset.com https://www.brickeconomy.com https://www.yourwebsite.com/lib/photos; " +
        "object-src 'none'; " +
        "script-src 'self' https://code.jquery.com; " +
        "style-src 'self' https://fonts.googleapis.com; " +
        "font-src 'self' https://fonts.gstatic.com; " +
        "upgrade-insecure-requests;");
    await next.Invoke();
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts(); // Now configured via IServiceCollection
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute("pagination", "{pageNum}", new { Controller = "Home", action = "EditProducts", pageNum = 1 });

//app.MapControllerRoute(
//    name: "pagination",
//    pattern: "EditProducts/{pageNum?}",
//    defaults: new { Controller = "Home", action = "EditProducts", pageNum = 1 });


//app.MapControllerRoute("pagination", "{pageNum}", new { Controller = "Home", action = "EditProducts", pageNum = 1 });

app.MapRazorPages();

app.Run();