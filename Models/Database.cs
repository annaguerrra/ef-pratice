namespace Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class ExampleDbContext(DbContextOptions opts) : DbContext(opts)
{
    public static async Task<ExampleDbContext> Create()
    {
        var connBuilder = new SqlConnectionStringBuilder
        {

            DataSource = "localhost",
            InitialCatalog = "EfPratice",
            IntegratedSecurity = true,
            TrustServerCertificate = true
        };
        var stringConnection = connBuilder.ToString();

        var optsBuilder = new DbContextOptionsBuilder();
        optsBuilder.UseSqlServer(stringConnection);
        var options = optsBuilder.Options;

        var db = new ExampleDbContext(options);
        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();

        return db;
    }

    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<UserData> UserDatas => Set<UserData>();
    public DbSet<ProductItens> ProductItems => Set<ProductItens>();
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<UserData>();
        model.Entity<ProductItens>();

        // venda - user
        model.Entity<Sale>()
            .HasOne(s => s.UserData)
            .WithMany(u => u.Sales)
            .HasForeignKey(i => i.UserDataID)
            .OnDelete(DeleteBehavior.Cascade);
            
        model.Entity<Sale>()
            .HasOne(p => p.ProductItem)
            .WithMany(u => u.Sales)
            .HasForeignKey(i => i.ProductItemID)
            .OnDelete(DeleteBehavior.Cascade);

    }
}

