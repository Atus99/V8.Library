using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using V8Hangfire.Domain.Models.Abstractions;
using V8Hangfire.Domain.Models.V8Hangfire;

namespace V8Hangfire.Infrastructure.Contexts
{
    public class V8HangfireContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public V8HangfireContext(DbContextOptions<V8HangfireContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public V8HangfireContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("V8Hangfire"));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {


            try
            {
                var modifiedEntries = ChangeTracker.Entries()
                    .Where(x => x.Entity is IAuditable
                                && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

                if (modifiedEntries.Any())
                {
                    foreach (var entry in modifiedEntries)
                    {
                        var entity = entry.Entity as IAuditable;
                        if (entity == null)
                        {
                            continue;
                        }

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy = 1;
                            entity.CreatedDate = DateTime.UtcNow;
                        }
                        else
                        {
                            entity.UpdatedBy = 1;
                            entity.UpdatedDate = DateTime.UtcNow;
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }

            return await base.SaveChangesAsync(true, cancellationToken);
        }

        public DbSet<JobSchedule> JobSchedule { get; set; }
    }
}
