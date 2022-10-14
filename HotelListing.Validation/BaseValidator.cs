using HotelListing.Entities.DTO;
using HotelListing.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Validation
{
    public abstract class BaseValidator<T, K> where T : BaseDTO
    {

        public ValidationMessageDto GetValidationMessage(ValidationCode code)
        {
            var msg = ValidationMessages.ResourceManager.GetString($"_{(int)code}") ?? code.ToString();
            return new ValidationMessageDto(code, msg);
        }

        public abstract List<ValidationMessageDto> Validate(T entity);

        public abstract List<ValidationMessageDto> ValidateDeletion(K id);
    }
}
