﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi2.Models;

#nullable disable

namespace TodoApi2.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20241206183323_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoApi2.Models.TodoItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("CompletionDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Secret")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CompletionDate = new DateOnly(2024, 12, 9),
                            IsComplete = false,
                            Name = "Quiz 5"
                        },
                        new
                        {
                            Id = 2L,
                            CompletionDate = new DateOnly(2024, 12, 9),
                            IsComplete = false,
                            Name = "Quiz 6"
                        },
                        new
                        {
                            Id = 3L,
                            CompletionDate = new DateOnly(2024, 12, 11),
                            IsComplete = false,
                            Name = "Exam 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
