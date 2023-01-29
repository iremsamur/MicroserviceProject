namespace BankManagementSystem.Services.Customer.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        //property'leri implemente ettim. 
        public string CustomerCollectionName { get; set; }
        public string CustomerAccountCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
