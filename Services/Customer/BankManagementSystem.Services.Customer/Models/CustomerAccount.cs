using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BankManagementSystem.Services.Customer.Models
{
    public class CustomerAccount
    {
        [BsonId]//bu prop'un id olduğunu belirttiğim mongo db attribute'u
        [BsonRepresentation(BsonType.ObjectId)]//id'nin unique olduğunu belirten attribute
        public string CustomerAccountId { get; set; }
        public string AccountName { get; set; }
        public string DateOpened { get; set; }
        public int AccountTypesCode { get; set; }

        //ilişkili tablolar için
        [BsonRepresentation(BsonType.ObjectId)]//yine id alanı unique
        public string CustomerId { get; set; }
        [BsonIgnore] //Bu annotasyon Customer için extra bir kolon oluşturmayıp sadece CustomerId'yi almayı sağlayarak böylece eşleştirmeyi sağlar.
        public Customer Customer { get; set; }
    }
}
