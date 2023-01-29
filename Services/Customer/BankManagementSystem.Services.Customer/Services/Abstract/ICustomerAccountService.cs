using BankManagementSystem.Services.Customer.DTOs;
using BankManagementSystem.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.Customer.Services.Abstract
{
    public interface ICustomerAccountService
    {
        Task<ResponseDTO<List<CustomerAccountListDTO>>> GetAllAsync();
        Task<ResponseDTO<CustomerAccountListDTO>> GetByIdAsync(string id);
        Task<ResponseDTO<CustomerAccountListDTO>> CreateAsync(CreateCustomerAccountDTO createCustomerAccountDto);
        //Burada Response ekleme sonucu verileri getireceği için Response'un kaynağı CustomerAccountList
        //Dto olur ama ekleme işlemi için eklenecek parametreleri tutan CreateCustomerAccountDto olur.

        //güncelleme işlemi
        //güncelleme ve silme işlemlerinde hiçbir şey dönmeyecek o yüzden NoContent olur.
        Task<ResponseDTO<NoContent>> UpdateAsync(UpdateCustomerAccountDTO updateCustomerAccountDto);

        //silme işlemi
        Task<ResponseDTO<NoContent>> DeleteAsync(string id);
    }
}
