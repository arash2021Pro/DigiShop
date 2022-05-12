using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.BasicDomain;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.SiteSettings;
using DigiShop.CoreBussiness.EfCoreDomains.StoreCategories;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.Users;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;
using DigiShop.CoreBussiness.RepsPattern;
using DigiShop.StorageService.EntityConfiguration;
using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.StorageService.SqlContext
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<SiteSetting>SiteSettings { get; set; }
        public DbSet<SignInLog>SignInLogs { get; set; }
        public DbSet<StoreCategory>StoreCategories { get; set; }
        public DbSet<Document>Documents { get; set; }


        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserConfiguration)));

            var entities = modelBuilder
                .Model
                .GetEntityTypes()
                .Select(x => x.ClrType)
                .Where(x => x.BaseType == typeof(Core))
                .ToList();

            foreach (var type in entities)
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] {modelBuilder});
            }
        }

        public static readonly MethodInfo SetGlobalQueryMethod = typeof(ApplicationContext)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : Core
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }


        private void changeEntitiesStates()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Core && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {

                if (entityEntry.State == EntityState.Added)
                {
                    ((Core) entityEntry.Entity).CurrentTime = DateTime.Now.ToShortPersianDateTimeString();
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((Core) entityEntry.Entity).ModificationTime = DateTime.Now.ToShortPersianDateTimeString();
                }
            }
        }
    }
}