using System;
using System.Collections.Generic;
using System.Linq;
using CodeTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace CodeTest
{
    public class CodeTestContext : DbContext
    {
        public CodeTestContext(DbContextOptions<CodeTestContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Class> Classes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(x =>
            {
                x.ToTable("Character").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("CharacterID");
                x.OwnsOne(p => p.Name, p =>
                {
                    p.Property(pp => pp.CharacterName).HasColumnName("CharacterName");
                    p.Property(pp => pp.PlayerName).HasColumnName("PlayerName");
                });
                x.OwnsOne(p => p.HitPoints, p =>
                {
                    p.Property(pp => pp.Current).HasColumnName("CurrentHitPoints");
                    p.Property(pp => pp.Max).HasColumnName("MaximumHitPoints");
                    p.Property(pp => pp.Temp).HasColumnName("TemporaryHitPoints");
                });
                x.OwnsOne(p => p.Stats, p =>
                {
                    p.Property(pp => pp.Strength).HasColumnName("Strength");
                    p.Property(pp => pp.Dexterity).HasColumnName("Dexterity");
                    p.Property(pp => pp.Constitution).HasColumnName("Constitution");
                    p.Property(pp => pp.Wisdom).HasColumnName("Wisdom");
                    p.Property(pp => pp.Intelligence).HasColumnName("Intelligence");
                    p.Property(pp => pp.Charisma).HasColumnName("Charisma");
                });
                x.HasMany(p => p.Classes).WithOne(p => p.Character)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                x.HasMany(p => p.Items).WithOne(p => p.Character)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
                x.HasMany(p => p.Defenses).WithOne(p => p.Character)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<Class>(x =>
            {
                x.ToTable("Class").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("ClassId");
                x.HasOne(p => p.Character).WithMany(p => p.Classes);
                x.Property(p => p.ClassLevel);
                x.Property(p => p.HitDiceValue);
                x.Property(p => p.Name);
            });

            modelBuilder.Entity<Item>(x =>
            {
                x.ToTable("Item").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("ItemId");
                x.HasOne(p => p.Character).WithMany(p => p.Items);
                x.OwnsOne(p => p.Modifier, p => 
                {
                    p.Property(pp => pp.AffectedObject).HasColumnName("AffectedObject");
                    p.Property(pp => pp.AffectedValue).HasColumnName("AffectedValue");
                    p.Property(pp => pp.Value).HasColumnName("Value");
                });

            });

            modelBuilder.Entity<Defense>(x =>
            {
                x.ToTable("Defense").HasKey(k => k.Id);
                x.Property(p => p.Id).HasColumnName("DefenseId");
                x.HasOne(p => p.Character).WithMany(p => p.Defenses);
                x.Property(p => p.Protection);
                x.Property(p => p.Type);
            });
        }
    }
}
