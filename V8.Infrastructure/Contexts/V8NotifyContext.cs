using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using V8.Domain.Models.V8Notify;

namespace V8.Infrastructure.Contexts
{
    public class V8NotifyContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public V8NotifyContext(DbContextOptions<V8NotifyContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public V8NotifyContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DASNotify"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            //builder.Entity<Job>().HasIndex(u => new { u.Name, u.ProjectId }).IsUnique();
            //builder.Entity<Project>().HasIndex(u => u.Name).IsUnique();
        }

        public DbSet<Notification> Notification { get; set; }
    }
}
