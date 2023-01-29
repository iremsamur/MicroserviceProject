using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Shared.DTOs
{
    public class ResponseDTO<T>
    {
        //yanıtı tutacak olan dto, generic olacak
        public T Data { get; set; }//Bu property, data içerisinde apiden gelen yanıttaki json türündeki veriler olacak.

        public int StatusCode { get; set; } //buda gelen yanıtın durum kodunu tutacak 200, 201 vb.
        public bool IsSuccessful { get; set; }//bu yanıtın başarılı olup olmadığını karşılar
        public List<string> Errors { get; set; }//bu hata olması durumunda hataların listesini tutacak

        //success metodu sonuç başarılı olunca dönecek sonucun metodu
        //bu apiden gelen istek başarılı olunca çalışacak
        public static ResponseDTO<T> Success(T data, int statusCode)
        {
            return new ResponseDTO<T>
            {
                Data = data,//mettota gönderilen data ve status kod ile eşleşir
                StatusCode = statusCode,
                //durum kodları postman api testlerinde kullanılacak
                IsSuccessful = true
            };
        }

        //buda sonuç başarılı olursa çalışacak ama yukarıdakinden farklı
        //overload olarak data değil sadece statuscode dönecek
        public static ResponseDTO<T> Success(int statusCode)
        {

            return new ResponseDTO<T>
            {
                Data = default(T),//default olarak T'den gelen değeri alır
                StatusCode = statusCode,
                IsSuccessful = true

            };

        }

        //şimdi sonuç başarısız olursa o durumda çalışacak metotları yazalım
        public static ResponseDTO<T> Fail(List<string> errors, int statusCode)
        {
           
            return new ResponseDTO<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false

            };
        }

        //şimdi fail için birden fazla hata değilde tek bir hata gelirse şu metod çalışsın

        public static ResponseDTO<T> Fail(string error, int statusCode)
        {
           
            return new ResponseDTO<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessful = false

            };
        }

    }
}
