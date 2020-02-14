using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AntcolonyProgram.Models
{
    public partial class AntcolonyContext : DbContext
    {
        public AntcolonyContext()
        {
        }

        public AntcolonyContext(DbContextOptions<AntcolonyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Power> Power { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectFile> ProjectFile { get; set; }
        public virtual DbSet<ProjectFileTag> ProjectFileTag { get; set; }
        public virtual DbSet<ProjectMessage> ProjectMessage { get; set; }
        public virtual DbSet<ProjectStateTable> ProjectStateTable { get; set; }
        public virtual DbSet<ProjectTaskList> ProjectTaskList { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
        public virtual DbSet<RolePostPower> RolePostPower { get; set; }
        public virtual DbSet<RolePostUser> RolePostUser { get; set; }
        public virtual DbSet<RoleTable> RoleTable { get; set; }
        public virtual DbSet<RootAdmin> RootAdmin { get; set; }
        public virtual DbSet<SpecialPermissionTable> SpecialPermissionTable { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamRelationUser> TeamRelationUser { get; set; }
        public virtual DbSet<TeamRolePostPower> TeamRolePostPower { get; set; }
        public virtual DbSet<TeamRoleTable> TeamRoleTable { get; set; }
        public virtual DbSet<TeamSpecialPermissionTableSet> TeamSpecialPermissionTableSet { get; set; }
        public virtual DbSet<TeamTypeTable> TeamTypeTable { get; set; }
        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyAddress).IsRequired();

                entity.Property(e => e.CompanyInfo).IsRequired();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.CompanyYearOfEstablishment).HasColumnType("datetime");

                entity.Property(e => e.CorporaterepResentative)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Power>(entity =>
            {
                entity.HasIndex(e => e.TeamRolePostPowerId)
                    .HasName("IX_FK_TeamRole_Post_PowerPower");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Method).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.Route)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.TeamRolePostPowerId).HasColumnName("TeamRole_Post_Power_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.TeamRolePostPower)
                    .WithMany(p => p.Power)
                    .HasForeignKey(d => d.TeamRolePostPowerId)
                    .HasConstraintName("FK_TeamRole_Post_PowerPower");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.ProjectStateTableId)
                    .HasName("IX_FK_ProjectStateTableProject");

                entity.HasIndex(e => e.ProjectTypeId)
                    .HasName("IX_FK_ProjectTypeProject");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.Edition)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.EstimatedTime).HasColumnType("datetime");

                entity.Property(e => e.ProjectImg).IsRequired();

                entity.Property(e => e.ProjectInfo).IsRequired();

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.ProjectStateTableId).HasColumnName("ProjectStateTable_Id");

                entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectType_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WareHourseUrl).IsRequired();

                entity.HasOne(d => d.ProjectStateTable)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ProjectStateTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectStateTableProject");

                entity.HasOne(d => d.ProjectType)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ProjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectTypeProject");
            });

            modelBuilder.Entity<ProjectFile>(entity =>
            {
                entity.HasIndex(e => e.ProjectFileTagId)
                    .HasName("IX_FK_ProjectFileProjectFileTag");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_FK_ProjectProjectFile");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.FileUrl).IsRequired();

                entity.Property(e => e.ProjectFileTagId).HasColumnName("ProjectFileTag_Id");

                entity.Property(e => e.ProjectId).HasColumnName("Project_Id");

                entity.Property(e => e.SuffixName)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.HasOne(d => d.ProjectFileTag)
                    .WithMany(p => p.ProjectFile)
                    .HasForeignKey(d => d.ProjectFileTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectFileProjectFileTag");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectFile)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectProjectFile");
            });

            modelBuilder.Entity<ProjectFileTag>(entity =>
            {
                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_FK_ProjectProjectFileTag");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("Project_Id");

                entity.Property(e => e.TagName).IsRequired();

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectFileTag)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectProjectFileTag");
            });

            modelBuilder.Entity<ProjectMessage>(entity =>
            {
                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_FK_ProjectProjectMessage");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.ProjectId).HasColumnName("Project_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectMessage)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectProjectMessage");
            });

            modelBuilder.Entity<ProjectStateTable>(entity =>
            {
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProjectTaskList>(entity =>
            {
                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_FK_ProjectProjectTaskList");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("Project_Id");

                entity.Property(e => e.TaskName).IsRequired();

                entity.Property(e => e.ToTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTaskList)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectProjectTaskList");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RolePostPower>(entity =>
            {
                entity.ToTable("Role_Post_Power");

                entity.HasIndex(e => e.PowerId)
                    .HasName("IX_FK_Role_Post_PowerPower");

                entity.HasIndex(e => e.RoleTableId)
                    .HasName("IX_FK_RoleTableRole_Post_Power");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.PowerId).HasColumnName("Power_Id");

                entity.Property(e => e.RoleTableId).HasColumnName("RoleTable_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Power)
                    .WithMany(p => p.RolePostPower)
                    .HasForeignKey(d => d.PowerId)
                    .HasConstraintName("FK_Role_Post_PowerPower");

                entity.HasOne(d => d.RoleTable)
                    .WithMany(p => p.RolePostPower)
                    .HasForeignKey(d => d.RoleTableId)
                    .HasConstraintName("FK_RoleTableRole_Post_Power");
            });

            modelBuilder.Entity<RolePostUser>(entity =>
            {
                entity.ToTable("Role_Post_User");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoleTable>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RootAdmin>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SpecialPermissionTable>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.CompanyId)
                    .HasName("IX_FK_CompanyTeam");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.TeamInfo).IsRequired();

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyTeam");
            });

            modelBuilder.Entity<TeamRelationUser>(entity =>
            {
                entity.ToTable("Team_Relation_User");

                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_FK_TeamTeam_Relation_User");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.TeamId).HasColumnName("Team_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserRemark).IsRequired();

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamRelationUser)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamTeam_Relation_User");
            });

            modelBuilder.Entity<TeamRolePostPower>(entity =>
            {
                entity.ToTable("TeamRole_Post_Power");

                entity.HasIndex(e => e.TeamRoleTableId)
                    .HasName("IX_FK_TeamRoleTableTeamRole_Post_Power");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.TeamRoleTableId).HasColumnName("TeamRoleTable_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.TeamRoleTable)
                    .WithMany(p => p.TeamRolePostPower)
                    .HasForeignKey(d => d.TeamRoleTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamRoleTableTeamRole_Post_Power");
            });

            modelBuilder.Entity<TeamRoleTable>(entity =>
            {
                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_FK_TeamTeamRoleTable");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.TeamId).HasColumnName("Team_Id");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamRoleTable)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamTeamRoleTable");
            });

            modelBuilder.Entity<TeamSpecialPermissionTableSet>(entity =>
            {
                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TeamTypeTable>(entity =>
            {
                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_FK_TeamTeamTypeTable");

                entity.Property(e => e.RemarkTag).IsRequired();

                entity.Property(e => e.TeamId).HasColumnName("Team_Id");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamTypeTable)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamTeamTypeTable");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.ProjectId)
                    .HasName("IX_FK_ProjectUser");

                entity.HasIndex(e => e.ProjectTaskListId)
                    .HasName("IX_FK_ProjectTaskListUser");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(124);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.ProjectId).HasColumnName("Project_Id");

                entity.Property(e => e.ProjectTaskListId).HasColumnName("ProjectTaskList_Id");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.RealyName)
                    .IsRequired()
                    .HasMaxLength(124);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectUser");

                entity.HasOne(d => d.ProjectTaskList)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ProjectTaskListId)
                    .HasConstraintName("FK_ProjectTaskListUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
