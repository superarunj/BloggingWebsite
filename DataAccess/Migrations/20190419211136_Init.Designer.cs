﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20190419211136_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Models.Category", b =>
                {
                    b.Property<short>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.HasIndex("Name");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = (short)1,
                            Name = "Bladder Cancer"
                        },
                        new
                        {
                            CategoryId = (short)2,
                            Name = "Breast Cancer"
                        },
                        new
                        {
                            CategoryId = (short)3,
                            Name = "Colorectal Cancer"
                        },
                        new
                        {
                            CategoryId = (short)4,
                            Name = "Kidney Cancer"
                        },
                        new
                        {
                            CategoryId = (short)5,
                            Name = "Lung Cancer"
                        },
                        new
                        {
                            CategoryId = (short)6,
                            Name = "Lymphoma Cancer"
                        },
                        new
                        {
                            CategoryId = (short)7,
                            Name = "Melanoma Cancer"
                        },
                        new
                        {
                            CategoryId = (short)8,
                            Name = "Oral and Oropharyngeal Cancer"
                        },
                        new
                        {
                            CategoryId = (short)9,
                            Name = "Pancreatic Cancer"
                        },
                        new
                        {
                            CategoryId = (short)10,
                            Name = "Prostate Cancer"
                        },
                        new
                        {
                            CategoryId = (short)11,
                            Name = "Thyroid Cancer"
                        },
                        new
                        {
                            CategoryId = (short)12,
                            Name = "Uterine Cancer"
                        },
                        new
                        {
                            CategoryId = (short)13,
                            Name = "Bone Cancer"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Approved");

                    b.Property<long>("PostId");

                    b.Property<DateTime>("PostedOn");

                    b.Property<long?>("ReplyOnId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("ReplyOnId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DataAccess.Models.Log", b =>
                {
                    b.Property<long>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.HasKey("LogId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("DataAccess.Models.Poll", b =>
                {
                    b.Property<int>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime?>("ActiveUntil");

                    b.Property<bool>("MultipleAnswers");

                    b.Property<string>("Question")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("PollId");

                    b.HasIndex("UserId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("DataAccess.Models.PollAnswer", b =>
                {
                    b.Property<int>("PollAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PollId");

                    b.HasKey("PollAnswerId");

                    b.HasIndex("PollId");

                    b.ToTable("PollAnswers");
                });

            modelBuilder.Entity("DataAccess.Models.Post", b =>
                {
                    b.Property<long>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("CategoryId");

                    b.Property<DateTime>("PostedOn");

                    b.Property<byte>("ReadTime");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DataAccess.Models.PostPhoto", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .IsRequired();

                    b.Property<long>("PostId");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.HasKey("PhotoId");

                    b.HasIndex("PostId");

                    b.ToTable("PostPhotos");
                });

            modelBuilder.Entity("DataAccess.Models.PostPoll", b =>
                {
                    b.Property<int>("PostPollId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PollId");

                    b.Property<long>("PostId");

                    b.HasKey("PostPollId");

                    b.HasIndex("PollId");

                    b.HasIndex("PostId");

                    b.ToTable("PostPolls");
                });

            modelBuilder.Entity("DataAccess.Models.PostTag", b =>
                {
                    b.Property<long>("PtId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PostId");

                    b.Property<short>("TagId");

                    b.HasKey("PtId");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("DataAccess.Models.Tag", b =>
                {
                    b.Property<short>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = (short)1,
                            Name = "Childhood"
                        },
                        new
                        {
                            TagId = (short)2,
                            Name = "Young"
                        },
                        new
                        {
                            TagId = (short)3,
                            Name = "Prevention"
                        },
                        new
                        {
                            TagId = (short)4,
                            Name = "Early Phase"
                        },
                        new
                        {
                            TagId = (short)5,
                            Name = "Tumor"
                        },
                        new
                        {
                            TagId = (short)6,
                            Name = "Cancer"
                        },
                        new
                        {
                            TagId = (short)7,
                            Name = "Leukemia"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Biography")
                        .IsRequired();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UrlFacebook");

                    b.Property<string>("UrlLinkedIn");

                    b.Property<string>("UrlTwitter");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DataAccess.Models.UserPhoto", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .IsRequired();

                    b.Property<string>("Source")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("PhotoId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserPhotos");
                });

            modelBuilder.Entity("DataAccess.Models.View", b =>
                {
                    b.Property<long>("ViewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAddress")
                        .IsRequired();

                    b.Property<long>("PostId");

                    b.HasKey("ViewId");

                    b.HasIndex("PostId");

                    b.ToTable("Views");
                });

            modelBuilder.Entity("DataAccess.Models.Vote", b =>
                {
                    b.Property<long>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PollAnswerId");

                    b.Property<int>("VotingGroupId");

                    b.HasKey("VoteId");

                    b.HasIndex("PollAnswerId");

                    b.HasIndex("VotingGroupId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("DataAccess.Models.VotingGroup", b =>
                {
                    b.Property<int>("VotingGroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("IpAddress")
                        .IsRequired();

                    b.Property<int>("PollId");

                    b.HasKey("VotingGroupId");

                    b.HasIndex("PollId");

                    b.ToTable("VotingGroups");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DataAccess.Models.Comment", b =>
                {
                    b.HasOne("DataAccess.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.Comment", "ReplyOn")
                        .WithMany()
                        .HasForeignKey("ReplyOnId");

                    b.HasOne("DataAccess.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.Poll", b =>
                {
                    b.HasOne("DataAccess.Models.User", "User")
                        .WithMany("Polls")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.PollAnswer", b =>
                {
                    b.HasOne("DataAccess.Models.Poll", "Poll")
                        .WithMany("PollAnswers")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.Post", b =>
                {
                    b.HasOne("DataAccess.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.PostPhoto", b =>
                {
                    b.HasOne("DataAccess.Models.Post", "Post")
                        .WithMany("Photos")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.PostPoll", b =>
                {
                    b.HasOne("DataAccess.Models.Poll", "Poll")
                        .WithMany("PostPolls")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.Post", "Post")
                        .WithMany("PostPolls")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.PostTag", b =>
                {
                    b.HasOne("DataAccess.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.UserPhoto", b =>
                {
                    b.HasOne("DataAccess.Models.User", "User")
                        .WithOne("Photo")
                        .HasForeignKey("DataAccess.Models.UserPhoto", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.View", b =>
                {
                    b.HasOne("DataAccess.Models.Post", "Post")
                        .WithMany("Views")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.Vote", b =>
                {
                    b.HasOne("DataAccess.Models.PollAnswer", "PollAnswer")
                        .WithMany("Votes")
                        .HasForeignKey("PollAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.VotingGroup", "VotingGroup")
                        .WithMany("Votes")
                        .HasForeignKey("VotingGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Models.VotingGroup", b =>
                {
                    b.HasOne("DataAccess.Models.Poll", "Poll")
                        .WithMany("VotingGroups")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataAccess.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataAccess.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataAccess.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
