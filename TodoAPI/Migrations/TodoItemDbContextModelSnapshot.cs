﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TodoAPI.Data;

#nullable disable

namespace TodoAPI.Migrations
{
    [DbContext(typeof(TodoItemDbContext))]
    partial class TodoItemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TodoAPI.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int?>("TodoItemsModelId")
                        .HasColumnType("integer");

                    b.HasKey("TagId");

                    b.HasIndex("TodoItemsModelId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("TodoAPI.Models.TodoItemsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("TodoAPI.Models.Tag", b =>
                {
                    b.HasOne("TodoAPI.Models.TodoItemsModel", null)
                        .WithMany("Tags")
                        .HasForeignKey("TodoItemsModelId");
                });

            modelBuilder.Entity("TodoAPI.Models.TodoItemsModel", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
