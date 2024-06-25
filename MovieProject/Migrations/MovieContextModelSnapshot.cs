﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieProject.Models;

#nullable disable

namespace MovieProject.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieProject.Models.Genre", b =>
                {
                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = "C",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = "D",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = "F",
                            Name = "Fantastic"
                        },
                        new
                        {
                            GenreId = "A",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = "Sc",
                            Name = "Science Fiction"
                        },
                        new
                        {
                            GenreId = "S",
                            Name = "Sport"
                        },
                        new
                        {
                            GenreId = "Hs",
                            Name = "Historical"
                        },
                        new
                        {
                            GenreId = "H",
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("MovieProject.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Description = "",
                            GenreId = "D",
                            Name = "The Godfather",
                            Rating = 5,
                            Year = 1972
                        },
                        new
                        {
                            MovieId = 2,
                            Description = "",
                            GenreId = "S",
                            Name = "The Pawn Sacrifice",
                            Rating = 4,
                            Year = 1942
                        },
                        new
                        {
                            MovieId = 3,
                            Description = "",
                            GenreId = "A",
                            Name = "The Matrix",
                            Rating = 4,
                            Year = 1999
                        });
                });

            modelBuilder.Entity("MovieProject.Models.Movie", b =>
                {
                    b.HasOne("MovieProject.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
