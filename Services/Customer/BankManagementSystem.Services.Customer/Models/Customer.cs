using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BankManagementSystem.Services.Customer.Models
{
    public class Customer
    {

        [BsonId]//bu prop'un id olduğunu belirttiğim mongo db attribute'u
        [BsonRepresentation(BsonType.ObjectId)]//id'nin unique olduğunu belirten attribute
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
