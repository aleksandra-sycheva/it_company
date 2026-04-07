using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace it_company.models;

public partial class ItCompanyContext : DbContext
{
    public ItCompanyContext()
    {
    }

    public ItCompanyContext(DbContextOptions<ItCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectMember> ProjectMembers { get; set; }

    public virtual DbSet<ProjectRole> ProjectRoles { get; set; }

    public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=it-company;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("priorities_pkey");

            entity.ToTable("priorities");

            entity.HasIndex(e => e.PriorityName, "priorities_priority_name_key").IsUnique();

            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(20)
                .HasColumnName("priority_name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.HasIndex(e => e.ProjectName, "projects_project_name_key").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(100)
                .HasColumnName("project_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Manager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_manager_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("projects_status_id_fkey");
        });

        modelBuilder.Entity<ProjectMember>(entity =>
        {
            entity.HasKey(e => e.ProjectMemberId).HasName("project_members_pkey");

            entity.ToTable("project_members");

            entity.HasIndex(e => new { e.ProjectId, e.UserId }, "project_members_project_id_user_id_key").IsUnique();

            entity.Property(e => e.ProjectMemberId).HasColumnName("project_member_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectRoleId).HasColumnName("project_role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("project_members_project_id_fkey");

            entity.HasOne(d => d.ProjectRole).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.ProjectRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("project_members_project_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("project_members_user_id_fkey");
        });

        modelBuilder.Entity<ProjectRole>(entity =>
        {
            entity.HasKey(e => e.ProjectRoleId).HasName("project_roles_pkey");

            entity.ToTable("project_roles");

            entity.HasIndex(e => e.RoleName, "project_roles_role_name_key").IsUnique();

            entity.Property(e => e.ProjectRoleId).HasColumnName("project_role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<ProjectStatus>(entity =>
        {
            entity.HasKey(e => e.ProjectStatusId).HasName("project_statuses_pkey");

            entity.ToTable("project_statuses");

            entity.HasIndex(e => e.StatusName, "project_statuses_status_name_key").IsUnique();

            entity.Property(e => e.ProjectStatusId).HasColumnName("project_status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(30)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_name_key").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("tasks_pkey");

            entity.ToTable("tasks");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.AssigneeId).HasColumnName("assignee_id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaskName)
                .HasMaxLength(200)
                .HasColumnName("task_name");

            entity.HasOne(d => d.Assignee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tasks_assignee_id_fkey");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_priority_id_fkey");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("tasks_project_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_status_id_fkey");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.TaskStatusId).HasName("task_statuses_pkey");

            entity.ToTable("task_statuses");

            entity.HasIndex(e => e.StatusName, "task_statuses_status_name_key").IsUnique();

            entity.Property(e => e.TaskStatusId).HasColumnName("task_status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(30)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
