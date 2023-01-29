using BankManagementSystem.Services.Customer.DTOs;
using BankManagementSystem.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.Customer.Services.Abstract
{
    public interface ICustomerService
    {
        //Customer CRUD işlemleri metotlarının gövdelerini tanımlayalım
        Task<ResponseDTO<List<CustomerListDTO>>> GetAllAsync();

        //ekleme işlemi
        Task<ResponseDTO<CustomerListDTO>> CreateAsync(CreateCustomerDTO createCustomerDto);
        //modeli burada kullanmıyoruz. Verileri dto'dan entity'e taşoyacak
        //o yüzden listeleme veya eklenecek veriler
        //dto üzerinde taşınır 

        Task<ResponseDTO<CustomerListDTO>> GetByIdAsync(string id);//id'ye göre veri getirme

    }
}
