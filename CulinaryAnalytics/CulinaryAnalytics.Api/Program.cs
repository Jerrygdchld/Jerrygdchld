using CulinaryAnalytics.Api.Auth;
using CulinaryAnalytics.Api.EndPoints;
using CulinaryAnalytics.Commands;
using CulinaryAnalytics.Models.Auth;
using CulinaryAnalytics.Repositories;
using CulinaryAnalytics.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.RegisterRepositories(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.RegisterCommands();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowCredentials();
                      });
});

builder.Services.AddDbContext<AuthDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddUserStore<ApplicationUserStore>()
    .AddRoleStore<ApplicationRoleStore>()
    .AddUserManager<ApplicationUserManager>()
    .AddClaimsPrincipalFactory<ApplicationClaimFactory>()
    ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.MapFallbackToFile("/index.html");

app.MapIdentityApi<ApplicationUser>();

UserEndPoints.Map(app);
AdminEndPoints.Map(app);

app.Run();
