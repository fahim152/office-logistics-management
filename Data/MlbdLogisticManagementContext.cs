namespace mlbd_logistic_management.Data;

using System;
using Microsoft.EntityFrameworkCore;

public partial class MlbdLogisticManagementContext : DbContext
{
    public MlbdLogisticManagementContext()
    {
    }

    public MlbdLogisticManagementContext(DbContextOptions<MlbdLogisticManagementContext> options)
        : base(options)
    {
    }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("mlbd_logistic_management");

            optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
