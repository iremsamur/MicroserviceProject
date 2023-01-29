namespace BankManagementSystem.Services.Customer.DTOs
{
    public class UpdateCustomerDTO
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
