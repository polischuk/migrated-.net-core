using data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hobby> Hobbies { get; set; }
        public virtual DbSet<ApplicationUserHobbies> ApplicationUserHobbies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ApplicationUserHobbies>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationUserId, e.HobbyId })
                    .HasName("PK_dbo.ApplicationUserHobbies");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_ApplicationUser_Id");

                entity.HasIndex(e => e.HobbyId)
                    .HasName("IX_Hobby_Id");

                entity.Property(e => e.ApplicationUserId)
                    .HasColumnName("ApplicationUser_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.HobbyId).HasColumnName("Hobby_Id");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.ApplicationUserHobbies)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.ApplicationUserHobbies_dbo.AspNetUsers_ApplicationUser_Id");

                entity.HasOne(d => d.Hobby)
                    .WithMany(p => p.ApplicationUserHobbies)
                    .HasForeignKey(d => d.HobbyId)
                    .HasConstraintName("FK_dbo.ApplicationUserHobbies_dbo.Hobbies_Hobby_Id");
            });
            modelBuilder.Entity<Hobby>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddedDate).HasColumnType("datetime");
            });
        }
    }
}
