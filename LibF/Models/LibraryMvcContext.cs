using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibF.Models;

namespace LibF.Models;

public partial class LibraryMvcContext : DbContext
{
    public LibraryMvcContext()
    {
    }

    public LibraryMvcContext(DbContextOptions<LibraryMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookDetail> BookDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=LibraryMVC;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookDetail>(entity =>
        {
            entity.HasKey(e => e.BookID).HasName("PK__BookDeta__3DE0C227A0FA921E");

            entity.Property(e => e.BookID)
                .ValueGeneratedNever()
                .HasColumnName("BookID");
            entity.Property(e => e.Author)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BookType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<LibF.Models.login_details> login_details { get; set; } = default!;
}
