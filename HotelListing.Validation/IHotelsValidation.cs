using HotelListing.API.Core.Models.Hotel;
using HotelListing.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Validation
{
    public interface IHotelsValidation 
    {
        List<ValidationMessageDto> Validate(HotelDto hotel);
        List<ValidationMessageDto> ValidateDeletion(long id);
    }
}
