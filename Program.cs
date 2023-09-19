using mlbd_logistic_management.Data;
using Microsoft.EntityFrameworkCore;
using mlbd_logistics_management.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using mlbd_logistics_management.Models;
using Microsoft.AspNetCore.Identity;
using mlbd_logistics_management.Utils;
using mlbd_logistics_management.Services.Interfaces;
using mlbd_logistic_management.Services.EmailSender;

var builder = WebApplication.CreateBuilder(args);

// Add JWT authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {     
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
    });

// Registering email service
builder.Services.AddTransient<IEmailSender, EmailSender>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register DbContext
builder.Services.AddDbContext<MlbdLogisticManagementContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("mlbd_logistic_management"));
});

// Register Identity
builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.User.AllowedUserNameCharacters = null;
}).AddEntityFrameworkStores<MlbdLogisticManagementContext>()
.AddDefaultTokenProviders();

// Register Services
builder.Services.AddScoped<IPaginationService, PaginationService>();
builder.Services.AddScoped<EmailSender>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<ItemTypeService>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<JwtUtils>();
builder.Services.AddHttpClient();    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
