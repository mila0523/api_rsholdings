using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_rsholdings.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientPayment> ClientPayments { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<InvoiceNote> InvoiceNotes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql8003.site4now.net;Database=db_a95e3e_rsholdingsdb;User ID=db_a95e3e_rsholdingsdb_admin;Password=river2@21;TrustServerCertificate=true;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__ADMINIST__59AF14B5C37DC505");

            entity.ToTable("ADMINISTRATORS");

            entity.Property(e => e.AdminId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ADMIN_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.ResetKey)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("RESET_KEY");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SURNAME");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__CLIENTS__1ED67F69937F32EA");

            entity.ToTable("CLIENTS");

            entity.Property(e => e.ClientId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLIENT_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CONTACT_PERSON");
            entity.Property(e => e.DateAdded)
                .HasColumnType("date")
                .HasColumnName("DATE_ADDED");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NAME");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.RegistrationNum)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("REGISTRATION_NUM");
            entity.Property(e => e.VatNum)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VAT_NUM");
        });

        modelBuilder.Entity<ClientPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__CLIENT_P__D2C4FF4637804638");

            entity.ToTable("CLIENT_PAYMENTS");

            entity.Property(e => e.PaymentId).HasColumnName("PAYMENT_ID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.ClientId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLIENT_ID");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("DATE");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientPayments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLIENT_PA__CLIEN__1BFD2C07");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceNum).HasName("PK__INVOICES__D753D6839E0142CF");

            entity.ToTable("INVOICES");

            entity.Property(e => e.InvoiceNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INVOICE_NUM");
            entity.Property(e => e.ClientId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLIENT_ID");
            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DELIVERY_STATUS");
            entity.Property(e => e.InvoiceDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INVOICE_DATE");
            entity.Property(e => e.InvoiceTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("INVOICE_TOTAL");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PAYMENT_STATUS");
            entity.Property(e => e.PricesUsed)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRICES_USED");

            entity.HasOne(d => d.Client).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__INVOICES__CLIENT__1DE57479");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__INVOICE___ADFD89A05D465E3D");

            entity.ToTable("INVOICE_ITEM");

            entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");
            entity.Property(e => e.InvoiceNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INVOICE_NUM");
            entity.Property(e => e.PrdCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRD_CODE");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            entity.HasOne(d => d.PrdCodeNavigation).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.PrdCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRD_CODE");
        });

        modelBuilder.Entity<InvoiceNote>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("PK__INVOICE___94BB952160154865");

            entity.ToTable("INVOICE_NOTES");

            entity.Property(e => e.NoteId).HasColumnName("NOTE_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.InvoiceNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INVOICE_NUM");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PrdCode).HasName("PK__PRODUCTS__647131E8F7C8C17A");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.PrdCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRD_CODE");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IMG_URL");
            entity.Property(e => e.PackSize)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PACK_SIZE");
            entity.Property(e => e.PalletSize)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PALLET_SIZE");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.SellingPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SELLING_PRICE");
            entity.Property(e => e.StockLevels).HasColumnName("STOCK_LEVELS");
            entity.Property(e => e.WaterpreneurPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("WATERPRENEUR_PRICE");
            entity.Property(e => e.WholesalePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("WHOLESALE_PRICE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
