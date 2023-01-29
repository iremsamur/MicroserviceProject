using AutoMapper;
using BankManagementSystem.Services.Customer.DTOs;
using BankManagementSystem.Services.Customer.Models;
using BankManagementSystem.Services.Customer.Services.Abstract;
using BankManagementSystem.Services.Customer.Settings;
using BankManagementSystem.Shared.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagementSystem.Services.Customer.Services.Concrete
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly IMongoCollection<CustomerAccount> _customerAccountCollection;
        //mongo db işlemleri için IMongoCollection'da kullanılır. Veritabanı işlemi olduğu için entity olan Category'i alır.
        private readonly IMapper _mapper;//mapleme için mapper'ı tanımlıyorum.

        public CustomerAccountService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);//IDatabaseSettings'den veritabanı bağlantı adresini alıyorum.
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _customerAccountCollection = database.GetCollection<CustomerAccount>(databaseSettings.CustomerAccountCollectionName);//customerAccount
                                                                                                                                 //collection tablosunun mongodb karşılığını alır.
            //mapper'ıda kullanalım
            _mapper = mapper;

        }
        //ekleme
        public async Task<ResponseDTO<CustomerAccountListDTO>> CreateAsync(CreateCustomerAccountDTO createCustomerAccountDto)
        {
            var customerAccount = _mapper.Map<CustomerAccount>(createCustomerAccountDto);//createCustomerAccountDTO'yu entity olan customeraccount ile eşleştirip ekleme yapacak
            await _customerAccountCollection.InsertOneAsync(customerAccount);
            return ResponseDTO<CustomerAccountListDTO>.Success(_mapper.Map<CustomerAccountListDTO>(customerAccount), 200); //datanın eklenmiş halini yanıtın sonucunu görmek için customerAccount'yu parametre olarak alır.
            //yine dto ve entity'i bağlamak için mapper ile maplenerek veri gönderiliyor

        }

        //silme
        public async Task<ResponseDTO<NoContent>> DeleteAsync(string id)
        {
            var result = await _customerAccountCollection.DeleteOneAsync(x => x.CustomerAccountId == id);//DeleteOneAsync içindeki id'ye göre silme yapar.
            if (result.DeletedCount > 0)
            {
                //silinen eleman sayısı>0 ise yani silme işlemi başarılı ise
                return ResponseDTO<NoContent>.Success(204);
                //silinen kaydı bana tekrar göstermesine gerek yok bu sebeple NoContent kullanıyorum.
                //Bu kez durum kodu 204 olur yani işlem başarılı ama geriye dönen bir içerik yok demektir.

            }
            else
            {
                return ResponseDTO<NoContent>.Fail("Silinecek hesap bulunamadı.", 404);//eğer başarısız olursa hata mesajı verecek fail overload'u kullanalım.
            }
        }

        //listeleme
        public async Task<ResponseDTO<List<CustomerAccountListDTO>>> GetAllAsync()
        {
            var customerAccounts = await _customerAccountCollection.Find(customerAccount => true).ToListAsync();
            return ResponseDTO<List<CustomerAccountListDTO>>.Success(_mapper.Map<List<CustomerAccountListDTO>>(customerAccounts), 200);
        }

        //id'ye göre getirme
        public async Task<ResponseDTO<CustomerAccountListDTO>> GetByIdAsync(string id)
        {
            var customerAccounts = await _customerAccountCollection.Find<CustomerAccount>(x => x.CustomerAccountId == id).FirstOrDefaultAsync();
            if (customerAccounts == null)
            {
                return ResponseDTO<CustomerAccountListDTO>.Fail("Girilen ID'ye ait  bir hesap bulunamadı.", 404);
            }
            else
            {
                return ResponseDTO<CustomerAccountListDTO>.Success(_mapper.Map<CustomerAccountListDTO>(customerAccounts), 200);

            }
        }

        //güncelleme
        public async Task<ResponseDTO<NoContent>> UpdateAsync(UpdateCustomerAccountDTO updateCustomerAccountDto)
        {
            var updatedAccount = _mapper.Map<CustomerAccount>(updateCustomerAccountDto);
            var result = await _customerAccountCollection.FindOneAndReplaceAsync(x => x.CustomerAccountId == updateCustomerAccountDto.CustomerAccountId, updatedAccount);
            //ikinci parametre güncellenmiş hali
            //ilk parametre neye göre güncellenecek ikincisi ise güncellenmiş yeni verilerin olduğu hali

            if (result == null)
            {
                return ResponseDTO<NoContent>.Fail("Güncellenecek hesap bulunamadı", 404);
            }
            else
            {
                return ResponseDTO<NoContent>.Success(204);
            }

        }
    }
}
