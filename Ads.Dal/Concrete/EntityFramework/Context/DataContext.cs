using Ads.Entities.Concrete;
using Ads.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ads.Dal.Concrete.EntityFramework.Context
{

  public class DataContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
  {
    public DataContext()
    {

    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Advert> Adverts { get; set; }
    public DbSet<AdvertComment> AdvertComments { get; set; }
    public DbSet<AdvertImage> AdvertImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryAdvert> CategoryAdverts { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //apply entitiy configurations
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      //modelBuilder.Entity<Advert>()
      //  .HasOne(a => a.User)
      //  .WithMany(u => u.Adverts)
      //  .HasForeignKey(a => a.UserId)
      //  .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Advert>()
          .HasMany(a => a.AdvertComments)
          .WithOne(ac => ac.Advert)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Advert>()
          .HasMany(a => a.AdvertImages)
          .WithOne(ai => ai.Advert)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<AdvertComment>()
    .HasOne(ac => ac.Advert)
    .WithMany(a => a.AdvertComments)
    .HasForeignKey(ac => ac.AdvertId)
    .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<AdvertImage>()
          .HasOne(ai => ai.Advert)
          .WithMany(a => a.AdvertImages)
          .HasForeignKey(ai => ai.AdvertId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<AppUser>()
    .HasMany(u => u.Adverts)
    .WithOne(a => a.User)
    .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Advert>()
      .HasOne(a => a.User)
      .WithMany(u => u.Adverts)
      .HasForeignKey(a => a.UserId)
      .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Category>()
    .HasMany(c => c.CategoryAdverts)
    .WithOne(ca => ca.Category)
    .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<CategoryAdvert>()
      .HasOne(ca => ca.Advert)
      .WithMany(a => a.CategoryAdverts)
      .HasForeignKey(ca => ca.AdvertId)
      .OnDelete(DeleteBehavior.Restrict);

    }

    public override int SaveChanges()
    {
      var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                 || e.State == EntityState.Modified));

      foreach (var entityEntry in entries)
      {
        ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

        if (entityEntry.State == EntityState.Added)
        {
          ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
        }
      }
      return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
      var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

      foreach (var entityEntry in entries)
      {
        if (entityEntry.State == EntityState.Modified)
        {
          entityEntry.Property("CreatedDate").IsModified = false;
          ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;
        }
        if (entityEntry.State == EntityState.Added)
        {
          ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;
          ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
        }
      }
      return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
  }

}
