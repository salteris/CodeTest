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
                x.HasMany(p => p.Classes).WithOne(p => p.Character)
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
        }
    }
}
