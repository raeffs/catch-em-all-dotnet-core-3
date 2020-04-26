﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raefftec.CatchEmAll;

namespace Raefftec.CatchEmAll.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Raefftec.CatchEmAll.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Raefftec.CatchEmAll.Entities.SearchQuery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SearchQueries");
                });

            modelBuilder.Entity("Raefftec.CatchEmAll.Entities.SearchResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QueryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("QueryId");

                    b.ToTable("SearchResults");
                });

            modelBuilder.Entity("Raefftec.CatchEmAll.Entities.UserReference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserReferences");
                });

            modelBuilder.Entity("Raefftec.CatchEmAll.Entities.Article", b =>
                {
                    b.OwnsOne("Raefftec.CatchEmAll.Types.ArticleInfo", "ArticleInfo", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTimeOffset>("Created")
                                .HasColumnType("datetimeoffset");

                            b1.Property<DateTimeOffset>("Ends")
                                .HasColumnType("datetimeoffset");

                            b1.Property<bool>("IsClosed")
                                .HasColumnType("bit");

                            b1.Property<bool>("IsSold")
                                .HasColumnType("bit");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsOne("Raefftec.CatchEmAll.Types.PriceInfo", "PriceInfo", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal?>("BidPrice")
                                .HasColumnType("decimal(18, 6)");

                            b1.Property<decimal?>("FinalPrice")
                                .HasColumnType("decimal(18, 6)");

                            b1.Property<decimal?>("PurchasePrice")
                                .HasColumnType("decimal(18, 6)");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsOne("Raefftec.CatchEmAll.Types.UpdateInfo", "UpdateInfo", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsLocked")
                                .HasColumnType("bit");

                            b1.Property<int>("NumberOfFailures")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("Updated")
                                .HasColumnType("datetimeoffset");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });
                });

            modelBuilder.Entity("Raefftec.CatchEmAll.Entities.SearchQuery", b =>
                {
                    b.HasOne("Raefftec.CatchEmAll.Entities.UserReference", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Raefftec.CatchEmAll.Types.SearchCriteria", "Criteria", b1 =>
                        {
                            b1.Property<Guid>("SearchQueryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("WithAllTheseWords")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.HasKey("SearchQueryId");

                            b1.ToTable("SearchQueries");

                            b1.WithOwner()
                                .HasForeignKey("SearchQueryId");
                        });

                    b.OwnsOne("Raefftec.CatchEmAll.Types.UpdateInfo", "UpdateInfo", b1 =>
                        {
                            b1.Property<Guid>("SearchQueryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsLocked")
                                .HasColumnType("bit");

                            b1.Property<int>("NumberOfFailures")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("Updated")
                                .HasColumnType("datetimeoffset");

                            b1.HasKey("SearchQueryId");

                            b1.ToTable("SearchQueries");

                            b1.WithOwner()
                                .HasForeignKey("SearchQueryId");
                        });
                });

            modelBuilder.Entity("Raefftec.CatchEmAll.Entities.SearchResult", b =>
                {
                    b.HasOne("Raefftec.CatchEmAll.Entities.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Raefftec.CatchEmAll.Entities.SearchQuery", "Query")
                        .WithMany("Results")
                        .HasForeignKey("QueryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
