using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using V8Notify.Domain.Models.Notify;

namespace V8Notify.Infrastructure.Contexts
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
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("V8Notify"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Notification> Notification { get; set; }
    }
}
