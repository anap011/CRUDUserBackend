﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDUser.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//       => optionsBuilder.UseSqlServer("server=DESKTOP-ANA\\SQLEXPRESS ; database=test; integrated security=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario);

            entity.ToTable("usuarios");

            entity.Property(e => e.Idusuario)
                .ValueGeneratedNever()
                .HasColumnName("IDUsuario");
            entity.Property(e => e.NameUsuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
