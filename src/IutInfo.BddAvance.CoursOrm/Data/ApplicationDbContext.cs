using System;
using System.Collections.Generic;
using System.Text;
using IutInfo.BddAvance.CoursOrm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IutInfo.BddAvance.CoursOrm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            builder.Entity<ApplicationUser>(b => { b.HasMany<Article>().WithOne().HasForeignKey(a => a.AuthorId); });

            builder.Entity<Article>(b => {
                b.HasKey(a => a.Id);
                b.ToTable("Article_ART");

                b.Property(a => a.Titre).HasMaxLength(256);
            });
            */
        }
    }
}
