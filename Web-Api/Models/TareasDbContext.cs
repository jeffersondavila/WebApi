﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api.Models
{
    public partial class TareasDbContext : DbContext
    {
        public TareasDbContext()
        {
        }

        public TareasDbContext(DbContextOptions<TareasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
                //You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see
                //https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Data Source=LAPTOP-07NSNMOC;Initial Catalog=TareasDb;user id=sa;password=loc@del@rea;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CodigoCategoria);

                entity.Property(e => e.CodigoCategoria).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(150);
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.CodigoTarea);

                entity.ToTable("Tarea");

                entity.HasIndex(e => e.CodigoCategoria, "IX_Tarea_CodigoCategoria");

                entity.Property(e => e.CodigoTarea).ValueGeneratedNever();

                entity.Property(e => e.Titulo).HasMaxLength(200);

                entity.HasOne(d => d.CodigoCategoriaNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.CodigoCategoria);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
