using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserManagmentAPI.Models;

public partial class VkTestDbContext : DbContext
{
    public VkTestDbContext()
    {
    }

    public VkTestDbContext(DbContextOptions<VkTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    public virtual DbSet<UserState> UserStates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("host=localhost;database=vk_test_db;username=postgres;password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasKey(e => e.Id).HasName("pk");
                
            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.UserGroupId).HasColumnName("user_group_id");
            entity.Property(e => e.UserStateId).HasColumnName("user_state_id");

            entity.HasOne(d => d.UserGroup).WithMany()
                .HasForeignKey(d => d.UserGroupId)
                .HasConstraintName("user_user_group_id_fkey");

            entity.HasOne(d => d.UserState).WithMany()
                .HasForeignKey(d => d.UserStateId)
                .HasConstraintName("user_user_state_id_fkey");
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_group_pkey");

            entity.ToTable("user_group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(7)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<UserState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_state_pkey");

            entity.ToTable("user_state");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(7)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
