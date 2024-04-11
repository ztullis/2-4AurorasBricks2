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

var app = builder.Build();

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

app.UseRouting();

app.UseAuthentication();    

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();