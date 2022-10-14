using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Entities.DTO
{
    public class BusinessResultSet<T>
    {
        public BusinessResultSet(T result)
        {
            IsSuccess = true;
            Result = result;
        }

        public BusinessResultSet(List<ValidationMessageDto> validations, bool isSuccess = false)
        {
            IsSuccess = isSuccess;
            Validations = validations;
        }

        public bool IsSuccess { get; set; }
        public List<ValidationMessageDto> Validations { get; } = new List<ValidationMessageDto>();
        public T Result { get; set; }
    }
}
