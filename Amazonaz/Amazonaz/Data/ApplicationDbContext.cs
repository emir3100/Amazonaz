using Microsoft.EntityFrameworkCore;
using Amazonaz.Server.Models;

namespace Amazonaz.Server.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    public DbSet<OrderModel> Orders { get; set; }

    public DbSet<ProductModel> Products { get; set; }

    //This constructur is used for ASP NET Core to get connection string from database via dependecy injections.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //This function is to specify tabel data
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<OrderModel>()
            .HasOne(i => i.User)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<OrderModel>()
            .HasOne(i => i.Product)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
