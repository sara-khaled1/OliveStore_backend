using Microsoft.EntityFrameworkCore;
using Npgsql;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
using sda_onsite_2_csharp_backend_teamwork.src.Enums;

namespace sda_onsite_2_csharp_backend_teamwork.src.Database;
public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    private IConfiguration _config;
    public DatabaseContext(IConfiguration config)
    {
        _config = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(@$"Host={_config["Db:Host"]};Username={_config["Db:Username"]};Database={_config["Db:Database"]};Password={_config["Db:Password"]};Port={_config["Db:Port"]}");
        dataSourceBuilder.MapEnum<Role>();
        dataSourceBuilder.MapEnum<Status>();
        var dataSource = dataSourceBuilder.Build();

        optionsBuilder.UseNpgsql(dataSource)
       .UseSnakeCaseNamingConvention();

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Role>();
        modelBuilder.HasPostgresEnum<Status>();
    }
}
