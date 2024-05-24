using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace StockManageBussinessObject.Models
{
    public partial class Stocks2024DBContext : DbContext
    {
        public Stocks2024DBContext()
        {
        }

        public Stocks2024DBContext(DbContextOptions<Stocks2024DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<StocksHistory> StocksHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            //return config["ConnectionStrings:DBConnect"];
            var strConn = config["ConnectionStrings:DBConnect"];
            return strConn ?? "";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.StockCode)
                    .HasName("PK__Stocks__28E08C96AAC1EF6C");

                entity.Property(e => e.StockCode).HasMaxLength(10);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.StockId)
                    .HasMaxLength(50)
                    .HasColumnName("StockID");

                entity.Property(e => e.StockName).HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<StocksHistory>(entity =>
            {
                entity.ToTable("StocksHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExchangeDate).HasColumnType("datetime");

                entity.Property(e => e.StockCode).HasMaxLength(10);

                entity.HasOne(d => d.StockCodeNavigation)
                    .WithMany(p => p.StocksHistories)
                    .HasForeignKey(d => d.StockCode)
                    .HasConstraintName("FK_StocksHistory_Stocks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
