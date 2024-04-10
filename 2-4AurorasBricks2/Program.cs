using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using System;
using _2_4AurorasBricks2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Azure.Security.KeyVault.Secrets;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.ConfigureAppConfiguration((context, config) =>
        {
            var builtConfig = config.Build();

            string kvUrl = builtConfig["KeyVaultConfig:KVURL"];
            string tenantId = builtConfig["KeyVaultConfig:TenantId"];
            string clientId = builtConfig["KeyVaultConfig:ClientId"];
            string clientSecret = builtConfig["KeyVaultConfig:ClientSecret"];

            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new SecretClient(new Uri(kvUrl), credential);

            config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
        });
    })
    .ConfigureServices((context, services) =>
    {
        // Add services and configuration to the DI container
        services.AddControllersWithViews();
        services.AddRazorPages();

        // Configure Entity Framework
        services.AddDbContext<LoginDbContext>(options =>
            options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<LegoContext>(options =>
            options.UseSqlite(context.Configuration.GetConnectionString("LegoConnection")));

        // Configure Identity
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredUniqueChars = 4;
        })
        .AddEntityFrameworkStores<LoginDbContext>()
        .AddDefaultTokenProviders();

        // Application Cookie settings
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/InsufficientPrivileges";
        });

        // Token lifespan
        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromHours(2);
        });

        // HSTS Configuration
        services.AddHsts(options =>
        {
            options.MaxAge = TimeSpan.FromDays(365);
            options.IncludeSubDomains = true;
            options.Preload = true;
        });
    })
    .Build();

host.Run();
