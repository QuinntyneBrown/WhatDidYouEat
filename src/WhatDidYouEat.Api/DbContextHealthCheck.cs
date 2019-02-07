using System.Threading;
using System.Threading.Tasks;
using WhatDidYouEat.Infrastructure;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WhatDidYouEat.Api
{
    public class DbContextHealthCheck : IHealthCheck
    {
        private readonly AppDbContext _context;

        public DbContextHealthCheck(AppDbContext context) 
            => _context = context;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
            => await _context.Database.CanConnectAsync(cancellationToken)
                ? HealthCheckResult.Healthy()
                : HealthCheckResult.Degraded();
    }
}