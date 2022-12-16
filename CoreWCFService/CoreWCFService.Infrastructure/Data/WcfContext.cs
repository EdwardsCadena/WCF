using System;
using System.Collections.Generic;
using CoreWCFService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreWCFService.Infrastructure.Data;

public partial class WcfContext : DbContext
{
    public WcfContext()
    {
    }

    public WcfContext(DbContextOptions<WcfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97F788581E");

            entity.ToTable("Usuario");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);
        });

    }

}
