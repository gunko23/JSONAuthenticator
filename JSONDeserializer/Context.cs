using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace JSONDeserializer
{
    public class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Initial Catalog=Hangouts; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Messages>()
                .HasKey(c => new { c.MessageId });

            modelBuilder.Entity<Contacts>()
                .HasKey(c => new { c.ContactId });
        }

    }
}
