using HotelListing.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Entities.DTO
{
    public class ValidationMessageDto
    {
        public ValidationMessageDto(ValidationCode code, string message, string exceptionMessage = null)
        {
            Code = ((int)code).ToString();
            Message = message;
            ExceptionMessage = exceptionMessage;
        }

        public string Code { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }
    }
}
