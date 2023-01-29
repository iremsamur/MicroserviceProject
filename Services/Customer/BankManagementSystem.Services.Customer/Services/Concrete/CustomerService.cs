using BankManagementSystem.Services.Customer.DTOs;
using BankManagementSystem.Services.Customer.Services.Abstract;
using BankManagementSystem.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.Customer.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        public Task<ResponseDTO<CustomerListDTO>> CreateAsync(CreateCustomerDTO createCustomerDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDTO<List<CustomerListDTO>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDTO<CustomerListDTO>> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
