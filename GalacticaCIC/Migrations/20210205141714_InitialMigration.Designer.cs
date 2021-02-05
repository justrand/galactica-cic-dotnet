﻿// <auto-generated />
using System;
using GalacticaCIC.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GalacticaCIC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210205141714_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GalacticaCIC.Domain.Character.AbilityEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Abilities", "public");
                });

            modelBuilder.Entity("GalacticaCIC.Domain.Character.CharacterEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long?>("AlternateVersionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ExpansionId")
                        .HasColumnType("bigint");

                    b.Property<int?>("InheritanceAdmiral")
                        .HasColumnType("integer");

                    b.Property<int?>("InheritanceCag")
                        .HasColumnType("integer");

                    b.Property<int?>("InheritancePresident")
                        .HasColumnType("integer");

                    b.Property<int>("LoyaltyWeight")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long?>("OncePerGameAbilityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OncePerTurnAbilityId")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<long?>("WeaknessId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AlternateVersionId");

                    b.HasIndex("ExpansionId");

                    b.HasIndex("OncePerGameAbilityId");

                    b.HasIndex("OncePerTurnAbilityId");

                    b.HasIndex("WeaknessId");

                    b.ToTable("Characters", "public");
                });

            modelBuilder.Entity("GalacticaCIC.Domain.Character.ExpansionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Expansions", "public");
                });

            modelBuilder.Entity("GalacticaCIC.Domain.Skill.SkillSetEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long?>("CharacterEntityId")
                        .HasColumnType("bigint");

                    b.Property<int>("DrawAmount")
                        .HasColumnType("integer");

                    b.Property<int>("PrimaryType")
                        .HasColumnType("integer");

                    b.Property<int>("SecondaryType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterEntityId");

                    b.ToTable("SkillSets", "public");
                });

            modelBuilder.Entity("GalacticaCIC.Domain.Character.CharacterEntity", b =>
                {
                    b.HasOne("GalacticaCIC.Domain.Character.CharacterEntity", "AlternateVersion")
                        .WithMany()
                        .HasForeignKey("AlternateVersionId");

                    b.HasOne("GalacticaCIC.Domain.Character.ExpansionEntity", "Expansion")
                        .WithMany()
                        .HasForeignKey("ExpansionId");

                    b.HasOne("GalacticaCIC.Domain.Character.AbilityEntity", "OncePerGameAbility")
                        .WithMany()
                        .HasForeignKey("OncePerGameAbilityId");

                    b.HasOne("GalacticaCIC.Domain.Character.AbilityEntity", "OncePerTurnAbility")
                        .WithMany()
                        .HasForeignKey("OncePerTurnAbilityId");

                    b.HasOne("GalacticaCIC.Domain.Character.AbilityEntity", "Weakness")
                        .WithMany()
                        .HasForeignKey("WeaknessId");

                    b.Navigation("AlternateVersion");

                    b.Navigation("Expansion");

                    b.Navigation("OncePerGameAbility");

                    b.Navigation("OncePerTurnAbility");

                    b.Navigation("Weakness");
                });

            modelBuilder.Entity("GalacticaCIC.Domain.Skill.SkillSetEntity", b =>
                {
                    b.HasOne("GalacticaCIC.Domain.Character.CharacterEntity", null)
                        .WithMany("Skills")
                        .HasForeignKey("CharacterEntityId");
                });

            modelBuilder.Entity("GalacticaCIC.Domain.Character.CharacterEntity", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
