﻿// <auto-generated />
using System;
using BookStoreServer.WebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreServer.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240205172010_mg4")]
    partial class mg4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreServer.WebApi.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("PublicationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStoreServer.WebApi.Models.BookCategory", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("BookStoreServer.WebApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Korku"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Bilim Kurgu"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Tarih"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Edebiyat"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Çocuk"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Psikoloji"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Din"
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Felsefe"
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Bilim"
                        },
                        new
                        {
                            Id = 10,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Sanat"
                        },
                        new
                        {
                            Id = 11,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Spor"
                        },
                        new
                        {
                            Id = 12,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Gezi"
                        },
                        new
                        {
                            Id = 13,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Dergi"
                        },
                        new
                        {
                            Id = 14,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Mizah"
                        },
                        new
                        {
                            Id = 15,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Kişisel Gelişim"
                        },
                        new
                        {
                            Id = 16,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Yemek"
                        },
                        new
                        {
                            Id = 17,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Hobi"
                        },
                        new
                        {
                            Id = 18,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Referans"
                        },
                        new
                        {
                            Id = 19,
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Eğitim"
                        });
                });

            modelBuilder.Entity("BookStoreServer.WebApi.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookStoreServer.WebApi.Models.BookCategory", b =>
                {
                    b.HasOne("BookStoreServer.WebApi.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreServer.WebApi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookStoreServer.WebApi.Models.Review", b =>
                {
                    b.HasOne("BookStoreServer.WebApi.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreServer.WebApi.Models.Book", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
