namespace BankManagementSystem.Services.Customer.Settings
{
    public interface IDatabaseSettings
    {
        //appsettings.json içinde yer alan DatabaseSettings attribute içindeki
        //tüm tanımladığım parametreleri yani sol taraftaki key değerlerini burada yazıyorum
        public string CustomerCollectionName { get; set; }//Müşteri tablo adı parametresi
        public string CustomerAccountCollectionName { get; set; }//Müşteri Hesapları tablosu adı parametresi
        public string ConnectionString { get; set; }//veritabanı bağlantı adresi
        public string DatabaseName { get; set; }//veritabanı adı
    }
}
