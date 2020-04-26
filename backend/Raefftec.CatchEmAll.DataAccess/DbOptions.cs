namespace Raefftec.CatchEmAll
{
    public class DbOptions
    {
        public string ConnectionString { get; set; } = string.Empty;

        public bool DeleteDatabaseOnMigrationFailure { get; set; }
    }
}
