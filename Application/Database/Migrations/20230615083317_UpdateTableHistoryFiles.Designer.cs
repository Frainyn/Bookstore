﻿// <auto-generated />
using Json.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Json.Migrations
{
    [DbContext(typeof(ConsoleAppDatabase))]
    [Migration("20230615083317_UpdateTableHistoryFiles")]
    partial class UpdateTableHistoryFiles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Json.Database.Entity.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("Json.Database.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Id1C")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AuthorID");

                    b.ToTable("books");
                });

            modelBuilder.Entity("Json.Database.Entity.HistoryFiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("import")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("historyFiles");
                });

            modelBuilder.Entity("Json.Database.Entity.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BookID");

                    b.ToTable("libraries");
                });

            modelBuilder.Entity("Json.Database.Entity.Book", b =>
                {
                    b.HasOne("Json.Database.Entity.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Json.Database.Entity.Library", b =>
                {
                    b.HasOne("Json.Database.Entity.Author", "Author")
                        .WithMany("Libraries")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Json.Database.Entity.Book", "Book")
                        .WithMany("Libraries")
                        .HasForeignKey("BookID")
                        .HasPrincipalKey("Id1C")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Json.Database.Entity.Author", b =>
                {
                    b.Navigation("Libraries");
                });

            modelBuilder.Entity("Json.Database.Entity.Book", b =>
                {
                    b.Navigation("Libraries");
                });
#pragma warning restore 612, 618
        }
    }
}