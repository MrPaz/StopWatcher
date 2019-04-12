﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StopWatcher.Data;

namespace StopWatcher.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190408204310_MarketData_Added_ExchangeID")]
    partial class MarketData_Added_ExchangeID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

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

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StopWatcher.Data.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID");

                    b.Property<string>("City");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("StopWatcher.Data.BTCPaymentAddress", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BTCAddress");

                    b.Property<int?>("BTCPaymentAddressID");

                    b.Property<DateTime>("DateGenerated");

                    b.HasKey("ID");

                    b.HasIndex("BTCPaymentAddressID");

                    b.ToTable("BTCPaymentAddresses");
                });

            modelBuilder.Entity("StopWatcher.Data.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BTCPaymentAddressID");

                    b.Property<int?>("CartID");

                    b.Property<int?>("PlanID");

                    b.Property<int>("PlansID");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.HasIndex("PlanID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("StopWatcher.Data.Exchange", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("APIKey");

                    b.Property<int>("MarketDataId");

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("StopWatcher.Data.ExchangeSecurity", b =>
                {
                    b.Property<int>("ExchangeID");

                    b.Property<int>("SecurityID");

                    b.HasKey("ExchangeID", "SecurityID");

                    b.HasIndex("SecurityID");

                    b.ToTable("ExchangeSecurities");
                });

            modelBuilder.Entity("StopWatcher.Data.MarketData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExchangeID");

                    b.Property<int?>("ExchangeID1");

                    b.Property<int?>("MarketSummarriesID");

                    b.HasKey("ID");

                    b.HasIndex("ExchangeID1");

                    b.HasIndex("MarketSummarriesID");

                    b.ToTable("MarketDatas");
                });

            modelBuilder.Entity("StopWatcher.Data.OpenOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BidPxBTC");

                    b.Property<double>("BidPxUSD");

                    b.Property<int>("ExchangeID");

                    b.Property<bool>("IsStop");

                    b.Property<int>("SecurityID");

                    b.Property<int?>("StopOrderID");

                    b.Property<double>("Units");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ExchangeID");

                    b.HasIndex("SecurityID");

                    b.HasIndex("StopOrderID")
                        .IsUnique()
                        .HasFilter("[StopOrderID] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("OpenOrders");
                });

            modelBuilder.Entity("StopWatcher.Data.Plan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Months");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("StopWatcher.Data.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExchangeID");

                    b.Property<bool>("IsStop");

                    b.Property<int>("SecurityID");

                    b.Property<double>("Units");

                    b.Property<string>("UserID");

                    b.Property<double>("WtdAvgBuyPriceBTC");

                    b.Property<double>("WtdAvgBuyPriceUSD");

                    b.HasKey("ID");

                    b.HasIndex("ExchangeID");

                    b.HasIndex("SecurityID");

                    b.HasIndex("UserID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("StopWatcher.Data.Security", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<double>("PxBTC");

                    b.Property<double>("PxUSD");

                    b.Property<string>("Ticker");

                    b.Property<string>("TradingPair");

                    b.HasKey("ID");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("StopWatcher.Data.StopOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PositionID");

                    b.Property<double>("StopPercent");

                    b.Property<double>("StopPriceBTC");

                    b.Property<double>("StopPriceUSD");

                    b.Property<double>("Units");

                    b.HasKey("ID");

                    b.HasIndex("PositionID");

                    b.ToTable("StopOrders");
                });

            modelBuilder.Entity("StopWatcher.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("AddressID");

                    b.Property<int?>("CartID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime?>("PlanEndDate");

                    b.Property<int?>("PlanID");

                    b.Property<DateTime?>("PlanStartDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.HasIndex("CartID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PlanID");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("StopWatcher.Models.GetMarketSummaryResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Ask");

                    b.Property<float>("BaseVolume");

                    b.Property<float>("Bid");

                    b.Property<DateTime>("Created");

                    b.Property<float>("High");

                    b.Property<float>("Last");

                    b.Property<float>("Low");

                    b.Property<string>("MarketName");

                    b.Property<int>("OpenBuyOrders");

                    b.Property<int>("OpenSellOrders");

                    b.Property<float>("PrevDay");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<float>("Volume");

                    b.HasKey("ID");

                    b.ToTable("GetMarketSummaryResult");
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
                    b.HasOne("StopWatcher.Data.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StopWatcher.Data.User")
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

                    b.HasOne("StopWatcher.Data.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StopWatcher.Data.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StopWatcher.Data.Address", b =>
                {
                    b.HasOne("StopWatcher.Data.Address")
                        .WithMany("_Address")
                        .HasForeignKey("AddressID");
                });

            modelBuilder.Entity("StopWatcher.Data.BTCPaymentAddress", b =>
                {
                    b.HasOne("StopWatcher.Data.BTCPaymentAddress")
                        .WithMany("_BTCPaymentAddresses")
                        .HasForeignKey("BTCPaymentAddressID");
                });

            modelBuilder.Entity("StopWatcher.Data.Cart", b =>
                {
                    b.HasOne("StopWatcher.Data.Cart")
                        .WithMany("_Cart")
                        .HasForeignKey("CartID");

                    b.HasOne("StopWatcher.Data.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanID");
                });

            modelBuilder.Entity("StopWatcher.Data.Exchange", b =>
                {
                    b.HasOne("StopWatcher.Data.User")
                        .WithMany("Exchanges")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("StopWatcher.Data.ExchangeSecurity", b =>
                {
                    b.HasOne("StopWatcher.Data.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StopWatcher.Data.Security", "Security")
                        .WithMany("ExchangeSecurities")
                        .HasForeignKey("SecurityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StopWatcher.Data.MarketData", b =>
                {
                    b.HasOne("StopWatcher.Data.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeID1");

                    b.HasOne("StopWatcher.Models.GetMarketSummaryResult", "MarketSummarries")
                        .WithMany()
                        .HasForeignKey("MarketSummarriesID");
                });

            modelBuilder.Entity("StopWatcher.Data.OpenOrder", b =>
                {
                    b.HasOne("StopWatcher.Data.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StopWatcher.Data.Security", "Security")
                        .WithMany()
                        .HasForeignKey("SecurityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StopWatcher.Data.StopOrder", "StopOrder")
                        .WithOne("OpenOrder")
                        .HasForeignKey("StopWatcher.Data.OpenOrder", "StopOrderID");

                    b.HasOne("StopWatcher.Data.User", "User")
                        .WithMany("OpenOrders")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("StopWatcher.Data.Position", b =>
                {
                    b.HasOne("StopWatcher.Data.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StopWatcher.Data.Security", "Security")
                        .WithMany()
                        .HasForeignKey("SecurityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StopWatcher.Data.User", "User")
                        .WithMany("Positions")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("StopWatcher.Data.StopOrder", b =>
                {
                    b.HasOne("StopWatcher.Data.Position", "Position")
                        .WithMany("StopOrders")
                        .HasForeignKey("PositionID");
                });

            modelBuilder.Entity("StopWatcher.Data.User", b =>
                {
                    b.HasOne("StopWatcher.Data.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("StopWatcher.Data.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartID");

                    b.HasOne("StopWatcher.Data.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanID");
                });
#pragma warning restore 612, 618
        }
    }
}
