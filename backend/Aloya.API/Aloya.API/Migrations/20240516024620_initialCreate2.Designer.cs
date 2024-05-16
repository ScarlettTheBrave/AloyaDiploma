﻿// <auto-generated />
using System;
using Aloya.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aloya.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240516024620_initialCreate2")]
    partial class initialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aloya.Domain.Auth.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("Aloya.Domain.Auth.UserAdmicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("userAdmicies");
                });

            modelBuilder.Entity("Aloya.Domain.Auth.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Avatar")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VerifyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PasswordId");

                    b.HasIndex("VerifyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aloya.Domain.Auth.Verify", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Verifys");
                });

            modelBuilder.Entity("Aloya.Domain.Module.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Answers.AreaAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaTaskId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRight")
                        .HasColumnType("bit");

                    b.Property<double>("Radius")
                        .HasColumnType("float");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AreaTaskId");

                    b.ToTable("AreaAnswers");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Answers.FormAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FormTaskId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRight")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormTaskId");

                    b.ToTable("FormAnswers");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Answers.ImageAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ImageTaskId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("isRight")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ImageTaskId");

                    b.ToTable("ImageAnswers");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.GlobalTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("MaxCost")
                        .HasColumnType("float");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("GlobalTests");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.AreaTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int?>("GlobalTestId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<byte[]>("photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("GlobalTestId");

                    b.ToTable("AreaTasks");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.FormTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int?>("GlobalTestId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GlobalTestId");

                    b.ToTable("FormTasks");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.ImageTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int?>("GlobalTestId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GlobalTestId");

                    b.ToTable("ImageTasks");
                });

            modelBuilder.Entity("Aloya.Domain.Theory.Illustration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("LectionId");

                    b.ToTable("Illustrations");
                });

            modelBuilder.Entity("Aloya.Domain.Theory.Lection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lections");
                });

            modelBuilder.Entity("Aloya.Domain.Theory.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LectionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LectionId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Aloya.Domain.Auth.UserAdmicy", b =>
                {
                    b.HasOne("Aloya.Domain.Auth.UserEntity", null)
                        .WithMany("Admicies")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("Aloya.Domain.Auth.UserEntity", b =>
                {
                    b.HasOne("Aloya.Domain.Auth.Password", "Password")
                        .WithMany()
                        .HasForeignKey("PasswordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aloya.Domain.Auth.Verify", "Verify")
                        .WithMany()
                        .HasForeignKey("VerifyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Password");

                    b.Navigation("Verify");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Answers.AreaAnswer", b =>
                {
                    b.HasOne("Aloya.Domain.Tests.Tasks.AreaTask", null)
                        .WithMany("AreaAnswers")
                        .HasForeignKey("AreaTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Answers.FormAnswer", b =>
                {
                    b.HasOne("Aloya.Domain.Tests.Tasks.FormTask", null)
                        .WithMany("Answers")
                        .HasForeignKey("FormTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Answers.ImageAnswer", b =>
                {
                    b.HasOne("Aloya.Domain.Tests.Tasks.ImageTask", null)
                        .WithMany("Images")
                        .HasForeignKey("ImageTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aloya.Domain.Tests.GlobalTest", b =>
                {
                    b.HasOne("Aloya.Domain.Module.Module", null)
                        .WithMany("Test")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.AreaTask", b =>
                {
                    b.HasOne("Aloya.Domain.Tests.GlobalTest", null)
                        .WithMany("AreaTests")
                        .HasForeignKey("GlobalTestId");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.FormTask", b =>
                {
                    b.HasOne("Aloya.Domain.Tests.GlobalTest", null)
                        .WithMany("FormTests")
                        .HasForeignKey("GlobalTestId");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.ImageTask", b =>
                {
                    b.HasOne("Aloya.Domain.Tests.GlobalTest", null)
                        .WithMany("ImageTests")
                        .HasForeignKey("GlobalTestId");
                });

            modelBuilder.Entity("Aloya.Domain.Theory.Illustration", b =>
                {
                    b.HasOne("Aloya.Domain.Theory.Lection", null)
                        .WithMany("Illustrations")
                        .HasForeignKey("LectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aloya.Domain.Theory.Lection", b =>
                {
                    b.HasOne("Aloya.Domain.Module.Module", null)
                        .WithMany("Lections")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aloya.Domain.Theory.Link", b =>
                {
                    b.HasOne("Aloya.Domain.Theory.Lection", null)
                        .WithMany("Links")
                        .HasForeignKey("LectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aloya.Domain.Auth.UserEntity", b =>
                {
                    b.Navigation("Admicies");
                });

            modelBuilder.Entity("Aloya.Domain.Module.Module", b =>
                {
                    b.Navigation("Lections");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.GlobalTest", b =>
                {
                    b.Navigation("AreaTests");

                    b.Navigation("FormTests");

                    b.Navigation("ImageTests");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.AreaTask", b =>
                {
                    b.Navigation("AreaAnswers");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.FormTask", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Aloya.Domain.Tests.Tasks.ImageTask", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Aloya.Domain.Theory.Lection", b =>
                {
                    b.Navigation("Illustrations");

                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
