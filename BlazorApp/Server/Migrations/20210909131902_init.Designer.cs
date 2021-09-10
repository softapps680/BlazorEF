﻿// <auto-generated />
using BlazorApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorApp.Server.Migrations
{
    [DbContext(typeof(BusinessContext))]
    [Migration("20210909131902_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorApp.Server.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Utrusning"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Skötsel"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Foder"
                        });
                });

            modelBuilder.Entity("BlazorApp.Server.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "I nylonmaterial",
                            ImageUrl = "https://www.hooks.se/pub_images/original/410247-2E_1.jpg?extend=copy&width=512&method=fit&height=512&type=webp&timestamp=1629121125",
                            Name = "Grimma",
                            categoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Perfekt resultat",
                            ImageUrl = "https://www.hooks.se/pub_images/original/820057-00-00000_1.jpg?extend=copy&width=512&method=fit&height=512&type=webp&timestamp=1624291521",
                            Name = "Pälsglans",
                            categoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Tillskott",
                            ImageUrl = "https://www.hooks.se/pub_images/original/820072-00-00000_1.jpg?extend=copy&width=512&method=fit&height=512&type=webp&timestamp=1617112200",
                            Name = "Biotin",
                            categoryId = 3
                        });
                });

            modelBuilder.Entity("BlazorApp.Server.Entities.Product", b =>
                {
                    b.HasOne("BlazorApp.Server.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BlazorApp.Server.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}