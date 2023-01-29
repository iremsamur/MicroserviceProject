using BankManagementSystem.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Shared.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(ResponseDTO<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode//override edip ezerek benim göndermiş olduğum formatta
                                                //ResponseDTO'ya göre göndermesini sağladım

            };

        }

    }
}
