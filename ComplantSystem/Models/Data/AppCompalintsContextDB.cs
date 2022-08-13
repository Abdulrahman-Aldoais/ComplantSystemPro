using ComplantSystem.Configuration;
using ComplantSystem.Models.Benef;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace ComplantSystem.Models
{
    public class AppCompalintsContextDB : IdentityDbContext<
         ApplicationUser,
        ApplicationRole, string>
    {
        public AppCompalintsContextDB(DbContextOptions<AppCompalintsContextDB> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppCompalintsContextDB).Assembly);


            modelBuilder.HasDefaultSchema("Identity");
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            modelBuilder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("UserTokens");
            });


            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            // add a navigation property relationship
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                //b.HasMany(e => e.RoleClaims)
                //    .WithOne(e => e.Role)
                //    .HasForeignKey(rc => rc.RoleId)
                //    .IsRequired();
            });
        
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });

            modelBuilder.Entity<Compalint>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<BenefCommunication>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Beneficiarie>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Proposal>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TypeComplaint>().Property(i => i.Id).HasDefaultValueSql("NEWID()");



        }


        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
        public DbSet<ApplicationUserToken> UserTokens { get; set; }
        public DbSet<ApplicationUserClaim> UserClaims { get; set; }
        public DbSet<ApplicationRoleClaim> RoleClaims { get; set; }
        public DbSet<ApplicationUserLogin> UserLogins { get; set; }
        public DbSet<TypeComplaint> TypeComplaints { get; set; }
        //public DbSet<TypeBeneficiari> TypeBeneficiaris { get; set; }
        public DbSet<Beneficiarie> Beneficiaries { get; set; }
        public DbSet<Compalint> UploadsComplainte { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Permission> Permissions { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Directorate> Directorates { get; set; }
        public DbSet<SubDirectorate> SubDirectorates { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<LimitationOrder> LimitationOrders { get; set; }
        public DbSet<UsersCommunication> UsersCommunications { get; set; }
        public DbSet<Compalints_Solution> Compalints_Solutions { get; set; }
        public DbSet<Society> Societys { get; set; }
        public DbSet<StagesComplaint> StagesComplaints { get; set; }
        public DbSet<StatusCompalint> StatusCompalints { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<UploadsComplainte> UploadsComplaintes { get; set; }
        
        //public DbSet<TypeCommunication> TypeCommunications { get; set; }






    }

}
