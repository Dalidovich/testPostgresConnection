using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using testPostgresConnection.Domain.Entities;

namespace testPostgresConnection.DAL
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public void UpdateDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Database=testForGitIgnore;Port=5432;User Id=postgres;Password=pg");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasKey(e => new { e.accountId })
                    .HasName("PK_Account_Id");

                entity.Property(e => e.accountId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnType("bigInt")
                    .HasColumnName("accountId");

                entity.Property(e => e.login)
                    .HasColumnType("text")
                    .HasColumnName("login");

                entity.Property(e => e.password)
                    .HasColumnType("text")
                    .HasColumnName("password");

                entity.Property(e => e.about)
                    .HasColumnType("text")
                    .HasColumnName("about");

                entity.Property(e => e.groupId)
                    .HasColumnType("bigInt")
                    .HasColumnName("groupId");
            });
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Groups");
                entity.HasKey(e => new { e.groupId })
                    .HasName("PK_Cabinet_Id");

                entity.Property(e => e.groupId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnType("bigInt")
                    .HasColumnName("groupId");

                entity.Property(e => e.title)
                    .HasColumnType("text")
                    .HasColumnName("title");
            });
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Group> Cabinets{ get; set; }
    }
}
