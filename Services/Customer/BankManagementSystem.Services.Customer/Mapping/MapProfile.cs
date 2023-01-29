using AutoMapper;
using BankManagementSystem.Services.Customer.DTOs;
using BankManagementSystem.Services.Customer.Models;

namespace BankManagementSystem.Services.Customer.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
           
            CreateMap<CustomerAccount, CustomerAccountListDTO>().ReverseMap();
            CreateMap<CustomerAccount, CreateCustomerAccountDTO>().ReverseMap();
            CreateMap<CustomerAccount, UpdateCustomerAccountDTO>().ReverseMap();

            //ReverseMap tersine maplemeyi de sağlar. Yani aşağıdaki kod ile aynı.
            // CreateMap<CustomerAccount, CustomerAccountListDTO>()
            // CreateMap<CustomerAccountListDTO,CustomerAccount>()

            CreateMap<BankManagementSystem.Services.Customer.Models.Customer, CustomerListDTO>().ReverseMap();
            CreateMap<BankManagementSystem.Services.Customer.Models.Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<BankManagementSystem.Services.Customer.Models.Customer, UpdateCustomerDTO>().ReverseMap();



        }
    }
}
