﻿// <auto-generated />
using System;
using FK3_skilaverkefni_EF_Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FK3_Skilaverkefni_WebApi.Migrations
{
    [DbContext(typeof(SchoolDBContext))]
    [Migration("20241108150903_subjects")]
    partial class subjects
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("StudentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("MarkId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarkId")
                        .HasColumnType("int");

                    b.Property<string>("SSID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("MarkId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<int?>("MarkId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.HasIndex("MarkId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersTeacherId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsSubjectId", "TeachersTeacherId");

                    b.HasIndex("TeachersTeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Group", b =>
                {
                    b.HasOne("FK3_skilaverkefni_EF_Core.Models.Student", null)
                        .WithMany("Group_Id")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Student", b =>
                {
                    b.HasOne("FK3_skilaverkefni_EF_Core.Models.Mark", null)
                        .WithMany("StudentId")
                        .HasForeignKey("MarkId");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Subject", b =>
                {
                    b.HasOne("FK3_skilaverkefni_EF_Core.Models.Mark", null)
                        .WithMany("Subject_id")
                        .HasForeignKey("MarkId");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("FK3_skilaverkefni_EF_Core.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FK3_skilaverkefni_EF_Core.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Mark", b =>
                {
                    b.Navigation("StudentId");

                    b.Navigation("Subject_id");
                });

            modelBuilder.Entity("FK3_skilaverkefni_EF_Core.Models.Student", b =>
                {
                    b.Navigation("Group_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
