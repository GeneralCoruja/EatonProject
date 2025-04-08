namespace EatonAPI.Database.Clients;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string DevicesCollection { get; set; } = null!;

    public string ReportsCollection { get; set; } = null!;
}