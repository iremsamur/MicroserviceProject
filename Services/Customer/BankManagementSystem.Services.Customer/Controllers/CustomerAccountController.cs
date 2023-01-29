using BankManagementSystem.Services.Customer.DTOs;
using BankManagementSystem.Services.Customer.Services.Abstract;
using BankManagementSystem.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : CustomBaseController //Yazdığımız ResponseDto mesajlarını kullanabilmek için CustomBaseController'dan miras alacak
    {
        private readonly ICustomerAccountService _customerAccountService;

        public CustomerAccountController(ICustomerAccountService customerAccountService)
        {
            _customerAccountService = customerAccountService;
        }
        //listeleme işlemi
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customerAccountService.GetAllAsync();
            return CreateActionResultInstance(response);
        }
        //id'ye göre getirme
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var response = await _customerAccountService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }
        //ekleme
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerAccountDTO createCustomerAccountDto)
        {
            var response = await _customerAccountService.CreateAsync(createCustomerAccountDto);
            return CreateActionResultInstance(response);
        }
        //güncelleme
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerAccountDTO updateCustomerAccountDto)
        {
            var response = await _customerAccountService.UpdateAsync(updateCustomerAccountDto);
            return CreateActionResultInstance(response);
        }
        //silme işlemi
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _customerAccountService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }

    }
}
