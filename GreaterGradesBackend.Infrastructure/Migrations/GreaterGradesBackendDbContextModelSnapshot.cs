﻿// <auto-generated />
using GreaterGradesBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreaterGradesBackend.Infrastructure.Migrations
{
    [DbContext(typeof(GreaterGradesBackendDbContext))]
    partial class GreaterGradesBackendDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<int>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClassId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("GradingStatus")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GradeId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Institution", b =>
                {
                    b.Property<int>("InstitutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstitutionId");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentClass", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("StudentClass");
                });

            modelBuilder.Entity("TeacherClass", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("TeacherClass");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("GreaterGradesBackend.Domain.Entities.Class", "Class")
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Class", b =>
                {
                    b.HasOne("GreaterGradesBackend.Domain.Entities.Institution", "Institution")
                        .WithMany("Classes")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Grade", b =>
                {
                    b.HasOne("GreaterGradesBackend.Domain.Entities.Assignment", "Assignment")
                        .WithMany("Grades")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreaterGradesBackend.Domain.Entities.User", "User")
                        .WithMany("Grades")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.User", b =>
                {
                    b.HasOne("GreaterGradesBackend.Domain.Entities.Institution", "Institution")
                        .WithMany("Users")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("StudentClass", b =>
                {
                    b.HasOne("GreaterGradesBackend.Domain.Entities.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreaterGradesBackend.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TeacherClass", b =>
                {
                    b.HasOne("GreaterGradesBackend.Domain.Entities.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GreaterGradesBackend.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Assignment", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Class", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Institution", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.User", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
