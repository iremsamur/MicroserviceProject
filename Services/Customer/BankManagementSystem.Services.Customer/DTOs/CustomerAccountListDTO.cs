using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BankManagementSystem.Services.Customer.DTOs
{
    public class CustomerAccountListDTO
    {
        public string CustomerAccountId { get; set; }
        public string AccountName { get; set; }
        public string DateOpened { get; set; }
        public int AccountTypesCode { get; set; }

      
        public string CustomerId { get; set; }
        
        public CustomerListDTO Customer { get; set; }
    }
}
