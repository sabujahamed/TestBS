﻿// <auto-generated />
using System;
using AspNetdbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetdbContext.Migrations
{
    [DbContext(typeof(AspContext))]
    [Migration("20201021163711_All")]
    partial class All
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNET.DTO.Comments", b =>
                {
                    b.Property<int>("CommentsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentContent");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<int>("PostID");

                    b.HasKey("CommentsID");

                    b.HasIndex("PostID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ASPNET.DTO.LikeOrDisLikes", b =>
                {
                    b.Property<int>("VoteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentsID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("LikeORDislike");

                    b.HasKey("VoteID");

                    b.HasIndex("CommentsID");

                    b.ToTable("LikeOrDisLikes");
                });

            modelBuilder.Entity("ASPNET.DTO.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("PostContent");

                    b.HasKey("PostID");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("ASPNET.DTO.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ASPNET.DTO.Comments", b =>
                {
                    b.HasOne("ASPNET.DTO.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ASPNET.DTO.LikeOrDisLikes", b =>
                {
                    b.HasOne("ASPNET.DTO.Comments", "Comments")
                        .WithMany("Vote")
                        .HasForeignKey("CommentsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
