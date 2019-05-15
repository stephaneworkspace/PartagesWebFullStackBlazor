﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartagesWebBlazorFSCore3.Server.Data;

namespace PartagesWebBlazorFSCore3.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190515122127_ForumMigration")]
    partial class ForumMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.ForumCategorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("ForumCategories");
                });

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.ForumPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ForumTopicId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ForumTopicId");

                    b.HasIndex("UserId");

                    b.ToTable("ForumPosts");
                });

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.ForumTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("ForumCategorieId");

                    b.Property<string>("Name");

                    b.Property<int>("View");

                    b.HasKey("Id");

                    b.HasIndex("ForumCategorieId");

                    b.ToTable("ForumTopics");
                });

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("SendByUserId");

                    b.Property<string>("Subject");

                    b.Property<bool>("SwRead");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<bool>("SwDeactivated");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.ForumPost", b =>
                {
                    b.HasOne("PartagesWebBlazorFSCore3.Shared.Models.ForumTopic", "ForumTopic")
                        .WithMany()
                        .HasForeignKey("ForumTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartagesWebBlazorFSCore3.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.ForumTopic", b =>
                {
                    b.HasOne("PartagesWebBlazorFSCore3.Shared.Models.ForumCategorie", "ForumCategorie")
                        .WithMany("ForumTopics")
                        .HasForeignKey("ForumCategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartagesWebBlazorFSCore3.Shared.Models.Message", b =>
                {
                    b.HasOne("PartagesWebBlazorFSCore3.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
