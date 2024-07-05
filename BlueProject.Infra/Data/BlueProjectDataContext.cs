using BlueProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlueProject.Infra.Data
{
    public class BlueProjectDataContext : DbContext
    {
        public BlueProjectDataContext() { }

        public BlueProjectDataContext(DbContextOptions<BlueProjectDataContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);
            });
        }
    }
}
