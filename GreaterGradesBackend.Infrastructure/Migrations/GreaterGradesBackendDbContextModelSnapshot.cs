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

                    b.Property<int>("MaxScore")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AssignmentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            AssignmentId = 1,
                            ClassId = 1,
                            MaxScore = 100,
                            Name = "assignment1"
                        },
                        new
                        {
                            AssignmentId = 2,
                            ClassId = 2,
                            MaxScore = 100,
                            Name = "assignment2"
                        },
                        new
                        {
                            AssignmentId = 3,
                            ClassId = 3,
                            MaxScore = 100,
                            Name = "assignment3"
                        },
                        new
                        {
                            AssignmentId = 4,
                            ClassId = 4,
                            MaxScore = 100,
                            Name = "assignment4"
                        },
                        new
                        {
                            AssignmentId = 5,
                            ClassId = 5,
                            MaxScore = 100,
                            Name = "assignment5"
                        },
                        new
                        {
                            AssignmentId = 6,
                            ClassId = 6,
                            MaxScore = 100,
                            Name = "assignment6"
                        },
                        new
                        {
                            AssignmentId = 7,
                            ClassId = 7,
                            MaxScore = 100,
                            Name = "assignment7"
                        },
                        new
                        {
                            AssignmentId = 8,
                            ClassId = 8,
                            MaxScore = 100,
                            Name = "assignment8"
                        });
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
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ClassId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            InstitutionId = 1,
                            Subject = "math1"
                        },
                        new
                        {
                            ClassId = 2,
                            InstitutionId = 2,
                            Subject = "math2"
                        },
                        new
                        {
                            ClassId = 3,
                            InstitutionId = 1,
                            Subject = "english1"
                        },
                        new
                        {
                            ClassId = 4,
                            InstitutionId = 2,
                            Subject = "english2"
                        },
                        new
                        {
                            ClassId = 5,
                            InstitutionId = 1,
                            Subject = "science1"
                        },
                        new
                        {
                            ClassId = 6,
                            InstitutionId = 2,
                            Subject = "science2"
                        },
                        new
                        {
                            ClassId = 7,
                            InstitutionId = 1,
                            Subject = "history1"
                        },
                        new
                        {
                            ClassId = 8,
                            InstitutionId = 2,
                            Subject = "history2"
                        });
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

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            AssignmentId = 1,
                            GradingStatus = 2,
                            Score = 20,
                            UserId = 1
                        },
                        new
                        {
                            GradeId = 2,
                            AssignmentId = 2,
                            GradingStatus = 2,
                            Score = 30,
                            UserId = 2
                        },
                        new
                        {
                            GradeId = 3,
                            AssignmentId = 3,
                            GradingStatus = 2,
                            Score = 40,
                            UserId = 3
                        },
                        new
                        {
                            GradeId = 4,
                            AssignmentId = 4,
                            GradingStatus = 2,
                            Score = 50,
                            UserId = 4
                        },
                        new
                        {
                            GradeId = 5,
                            AssignmentId = 5,
                            GradingStatus = 2,
                            Score = 60,
                            UserId = 7
                        },
                        new
                        {
                            GradeId = 6,
                            AssignmentId = 6,
                            GradingStatus = 2,
                            Score = 70,
                            UserId = 8
                        });
                });

            modelBuilder.Entity("GreaterGradesBackend.Domain.Entities.Institution", b =>
                {
                    b.Property<int>("InstitutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstitutionId");

                    b.ToTable("Institutions");

                    b.HasData(
                        new
                        {
                            InstitutionId = 1,
                            Address = "1600 Pennsylvania Avenue NW, Washington, DC 20500",
                            Name = "Institution 1"
                        },
                        new
                        {
                            InstitutionId = 2,
                            Address = "600 1st St W, Mt Vernon, IA 52314",
                            Name = "Institution 2"
                        });
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

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "student1",
                            InstitutionId = 1,
                            LastName = "student1",
                            PasswordHash = "AQAAAAEAACcQAAAAEKYoZHkxTGVeIfWkvnOh8IYOqu0ayjWhY7Ly4qddZGIAqNH+eciYUsJRZ3FhGd9FsQ==",
                            Role = 0,
                            Username = "student1"
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "student2",
                            InstitutionId = 2,
                            LastName = "student2",
                            PasswordHash = "AQAAAAEAACcQAAAAEGaxIJ+nnFKgEhf7cTvZLhRrwz/3wNEv2ygdzxddS65PLjugfY1cX+wO+cwIJEXYBg==",
                            Role = 0,
                            Username = "student2"
                        },
                        new
                        {
                            UserId = 3,
                            FirstName = "studentTA1",
                            InstitutionId = 1,
                            LastName = "studentTA1",
                            PasswordHash = "AQAAAAEAACcQAAAAEIZB+6w/d6M3RvHF18h0Rx2mzAAy7sbuZZGyRe2iodNU3ox9UuzUXeeZPf6TcKMG+w==",
                            Role = 0,
                            Username = "studentTA1"
                        },
                        new
                        {
                            UserId = 4,
                            FirstName = "studentTA2",
                            InstitutionId = 2,
                            LastName = "studentTA2",
                            PasswordHash = "AQAAAAEAACcQAAAAEC0LlGhOZ9NpLizaSjq7uSLJDgwvy5sartUEAXGbcYND1XA/c2TqqqUHIGhDqwpdIQ==",
                            Role = 0,
                            Username = "studentTA2"
                        },
                        new
                        {
                            UserId = 5,
                            FirstName = "teacher1",
                            InstitutionId = 1,
                            LastName = "teacher1",
                            PasswordHash = "AQAAAAEAACcQAAAAEH/VQIn32a1fYSq1j4ITuA5G0YwBXNcoW/mguErpmaFQlt9Oz3En9vRQxza8fRpUdA==",
                            Role = 1,
                            Username = "teacher1"
                        },
                        new
                        {
                            UserId = 6,
                            FirstName = "teacher2",
                            InstitutionId = 2,
                            LastName = "teacher2",
                            PasswordHash = "AQAAAAEAACcQAAAAEDHZ9QLWRmi0K8wbwWu1cwGbcknK8aydsDIMbQWbflqucdGFF631NMvtdwTiQ3vcbQ==",
                            Role = 1,
                            Username = "teacher2"
                        },
                        new
                        {
                            UserId = 7,
                            FirstName = "teacherST1",
                            InstitutionId = 1,
                            LastName = "teacherST1",
                            PasswordHash = "AQAAAAEAACcQAAAAEA6lcBizk0xW4cBP+kTHi8WIvr6JWRVUoau8LOb2U8x0EFzdgz2u2LBU9NkI06Yl/w==",
                            Role = 1,
                            Username = "teacherST1"
                        },
                        new
                        {
                            UserId = 8,
                            FirstName = "teacherST2",
                            InstitutionId = 2,
                            LastName = "teacherST2",
                            PasswordHash = "AQAAAAEAACcQAAAAEE/O7A0Eif8GY4x2ha8/a2MPWpFIhWISg+hF1c7p6GT22is2XZzFHReaeC6UujhpRA==",
                            Role = 1,
                            Username = "teacherST2"
                        },
                        new
                        {
                            UserId = 9,
                            FirstName = "iadmin1",
                            InstitutionId = 1,
                            LastName = "iadmin1",
                            PasswordHash = "AQAAAAEAACcQAAAAEOuQFptg+wVk4TlGRCDFBq+4RgADeYgjabeiT07L09MI13WAamqQiHYAAAJ7aFlh0A==",
                            Role = 2,
                            Username = "iadmin1"
                        },
                        new
                        {
                            UserId = 10,
                            FirstName = "iadmin2",
                            InstitutionId = 2,
                            LastName = "iadmin2",
                            PasswordHash = "AQAAAAEAACcQAAAAEGLWd9tCi26Bc8d2Y4h+Gxm9JMi0aukUTUTBPIB23rX8WXeq8A8ueIRGU8lzTSL+vw==",
                            Role = 2,
                            Username = "iadmin2"
                        },
                        new
                        {
                            UserId = 11,
                            FirstName = "admin1",
                            InstitutionId = 1,
                            LastName = "admin1",
                            PasswordHash = "AQAAAAEAACcQAAAAECxOdlTnq1C4DEyjw0KAIjGabglMBJhbzylP2RKUQIGraohq7lXk7Kav5Q78dMAfxA==",
                            Role = 3,
                            Username = "admin1"
                        },
                        new
                        {
                            UserId = 12,
                            FirstName = "admin2",
                            InstitutionId = 2,
                            LastName = "admin2",
                            PasswordHash = "AQAAAAEAACcQAAAAEDsaD86FQLRxSF4HmE2ZuRaZ9FZYk5xJC4VMldDmnPvunqZOZn6ufXNF4aA/hGGhNg==",
                            Role = 3,
                            Username = "admin2"
                        });
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

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            UserId = 1
                        },
                        new
                        {
                            ClassId = 2,
                            UserId = 2
                        },
                        new
                        {
                            ClassId = 3,
                            UserId = 3
                        },
                        new
                        {
                            ClassId = 4,
                            UserId = 4
                        },
                        new
                        {
                            ClassId = 5,
                            UserId = 7
                        },
                        new
                        {
                            ClassId = 6,
                            UserId = 8
                        });
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

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            UserId = 3
                        },
                        new
                        {
                            ClassId = 2,
                            UserId = 4
                        },
                        new
                        {
                            ClassId = 3,
                            UserId = 5
                        },
                        new
                        {
                            ClassId = 4,
                            UserId = 6
                        },
                        new
                        {
                            ClassId = 5,
                            UserId = 7
                        },
                        new
                        {
                            ClassId = 6,
                            UserId = 8
                        });
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
