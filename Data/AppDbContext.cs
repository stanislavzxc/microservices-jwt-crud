using Microsoft.EntityFrameworkCore;
using microservices_jwt_crud.Data.Models;

namespace microservices_jwt_crud.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users {get;set;}
    public DbSet<CardModel> Cards {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserModel> (entity => 
        {
            entity.ToTable("users");

            entity.HasKey(u => u.id);

            entity.Property(u => u.name)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(u => u.email)
                .HasMaxLength(100)
                .IsRequired();
            entity.HasIndex(u => u.email)
                .IsUnique();

            entity.Property(u => u.role)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(u => u.password)
                .IsRequired();

        });

        modelBuilder.Entity<CardModel> (entity => 
        {
            entity.ToTable("cards");

            entity.HasKey(u => u.id);

            entity.Property(u => u.name)
                .HasMaxLength(100)
                .IsRequired();
            
            entity.Property(u => u.price)
                .HasColumnType("numeric(10,2)")
                .IsRequired();
            
            entity.HasOne(c => c.User)
                .WithMany(u => u.Cards) 
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);               
                
        });
    }

}