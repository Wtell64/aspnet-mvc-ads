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
    public DbSet<SubcategoryAdvert> SubcategoryAdverts { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    public override int SaveChanges()
    {
      var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                 || e.State == EntityState.Modified));

			var users = ChangeTracker
				.Entries()
				.Where(e => e.Entity is AppUser && (
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

			foreach (var entityUser in users)
			{
				((AppUser)entityUser.Entity).UpdatedDate = DateTime.Now;

				if (entityUser.State == EntityState.Added)
				{
					((AppUser)entityUser.Entity).CreatedDate = DateTime.Now;
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
			var users = ChangeTracker
				.Entries()
				.Where(e => e.Entity is AppUser && (
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

			foreach (var entityUser in users)
			{
				if (entityUser.State == EntityState.Modified)
				{
					entityUser.Property("CreatedDate").IsModified = false;
					((AppUser)entityUser.Entity).UpdatedDate = DateTime.Now;
				}
				if (entityUser.State == EntityState.Added)
				{
					((AppUser)entityUser.Entity).UpdatedDate = DateTime.Now;
					((AppUser)entityUser.Entity).CreatedDate = DateTime.Now;
				}
			}
			return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
  }

}
