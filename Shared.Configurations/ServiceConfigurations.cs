namespace Shared.Configuration
{
    public class ServiceConfigurations
    {
        public const string Service = "Service";
        
        public const string DataBase = "DataBase";

        public string MainModule { get; set; }
        
        public string MSSSQLUser { get; set; }
        
        public string MSSSQLPassword { get; set; }
        
        public string MSSSQLConnectionString { get; set; }
        
        public string MSSSQLCatalog { get; set; }
        
        public string MSSSQLDataSource { get; set; }
    }
}