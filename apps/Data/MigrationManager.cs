
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PlaneTicketSystem.Data.Migrations
{
    public class MigrationManager
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MigrationManager> _logger;

        public MigrationManager(ApplicationDbContext context, ILogger<MigrationManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task InitializeDatabaseAsync()
        {
            try
            {
                //ensures the database is created
                await _context.Database.EnsureCreatedAsync();

                await CreateMigrationHistoryTableAsync();

                // Execute pending migrations
                await ExecutePendingMigrationsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database");
                throw;
            }
        }
        private async Task CreateMigrationHistoryTableAsync()
        {
            const string createHistoryTableSql = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DatabaseMigrationHistory')
                BEGIN
                    CREATE TABLE DatabaseMigrationHistory (
                        MigrationId VARCHAR(100) PRIMARY KEY,
                        AppliedOn DATETIME2 DEFAULT GETDATE()
                    )
                END";
            await _context.Database.ExecuteSqlRawAsync(createHistoryTableSql);
        }
        private async Task ExecutePendingMigrationsAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var migrationFiles = assembly.GetManifestResourceNames()
                .Where(name => name.Contains("Release_2024_12.V"))
                .OrderBy(name => name)
                .ToList();

            foreach(var migrationFile in migrationFiles)
            {
                var migrationId = Path.GetFileNameWithoutExtension(migrationFile);

                // Check if migration was already applied
                var migrationExists = await _context.Database
                    .SqlQuery<int>($"SELECT COUNT(1) FROM DatabaseMigrationHistory WHERE MigrationId = '{migrationId}'")
                    .FirstOrDefaultAsync();

                if (migrationExists == 0)
                {
                    _logger.LogInformation($"Applying migration: {migrationId}");

                    using var stream = assembly.GetManifestResourceStream(migrationFile);
                    if (stream == null)
                    {
                        _logger.LogError($"Could not find migration file: {migrationFile}");
                        return;
                    }
                    using var reader = new StreamReader( stream);
                    var sql = await reader.ReadToEndAsync();

                    using var transaction = await _context.Database.BeginTransactionAsync();
                    try
                    {
                        await _context.Database.ExecuteSqlRawAsync(sql);
                        await _context.Database.ExecuteSqlRawAsync(
                            "INSERT INTO DatabaseMigrationHistory (MigrationId) VALUES ({0})",
                            migrationId);

                        await transaction.CommitAsync();
                        _logger.LogInformation($"Successfully applied migration: {migrationId}");
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        _logger.LogError(ex, $"Error applying migration: {migrationId}");
                        throw;
                    }
                }

            }
        }
    }
}