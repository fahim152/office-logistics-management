using mlbd_logistic_management.Data;
using Microsoft.EntityFrameworkCore;
using mlbd_logistics_management.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<MlbdLogisticManagementContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("mlbd_logistic_management"));
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql");
});

// Register DepartmentService
builder.Services.AddScoped<DepartmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
