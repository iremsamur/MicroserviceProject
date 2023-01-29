namespace BankManagementSystem.Services.Customer.DTOs
{
    public class UpdateCustomerAccountDTO
    {
        public string CustomerAccountId { get; set; }
        public string AccountName { get; set; }
        public string DateOpened { get; set; }
        public int AccountTypesCode { get; set; }


        public string CustomerId { get; set; }
    }
}
