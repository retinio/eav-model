using System;
using EVA.Infrastructure.Data.Abstractions.Migrations;
using EVA.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EVA.Infrastructure.Data.Migrations
{
    public class EvaMigrationsProvider: IMigrationsProvider
    {
        private readonly EvaContext _context;
        private readonly ILogger _logger;

        public EvaMigrationsProvider(EvaContext context, ILoggerFactory loggerFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));

            _logger = loggerFactory.CreateLogger<EvaMigrationsProvider>();            
        }
        
        public virtual bool Migrate()
        {
            try
            {
                _context.Database.Migrate();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "DB - {CONTEXT MIGRATION} error", _context.GetType().FullName);
            }

            return false;
        }
    }
}