using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookAPI.Models
{
    public partial class BookAppDBContext : DbContext
    {
        public BookAppDBContext()
        {
        }

        public BookAppDBContext(DbContextOptions<BookAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDet> BookDets { get; set; }
        public virtual DbSet<TblInvoice> TblInvoices { get; set; }
        public virtual DbSet<TblPayment> TblPayments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET840;Initial Catalog=BookAppDB;User ID=sa; password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookDet>(entity =>
            {
                entity.ToTable("BookDet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookCategory).HasMaxLength(50);

                entity.Property(e => e.BookContent).HasMaxLength(500);

                entity.Property(e => e.BookImg).HasMaxLength(50);

                entity.Property(e => e.BookPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.BookPublish).HasMaxLength(50);

                entity.Property(e => e.BookTitle).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModyDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasMaxLength(50);
            });

            modelBuilder.Entity<TblInvoice>(entity =>
            {
                entity.HasKey(e => new { e.Year, e.Month });

                entity.ToTable("tblInvoice");

                entity.Property(e => e.Year).HasMaxLength(50);

                entity.Property(e => e.Month).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("tblPayment");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.CancelOrder).HasColumnName("cancelOrder");

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.PaymentBy).HasColumnName("paymentBy");

                entity.Property(e => e.PaymentCard)
                    .HasMaxLength(50)
                    .HasColumnName("paymentCard");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("paymentDate");

                entity.Property(e => e.PaymentName)
                    .HasMaxLength(50)
                    .HasColumnName("paymentName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Email });

                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
