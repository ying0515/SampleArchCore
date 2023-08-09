using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model.Database.POCO;

namespace SampleArch.Model.Database;

public partial class SampleArchContext : DbContext
{
    public SampleArchContext()
    {
    }

    public SampleArchContext(DbContextOptions<SampleArchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Country { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspace\\Samples\\SampleArchCore\\SampleArchCore.Web\\DatabaseFile\\SampleArch.mdf;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC07FB9762AB");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC071909950D");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(256)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(256)
                .IsFixedLength();
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
