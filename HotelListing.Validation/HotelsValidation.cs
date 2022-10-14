using HotelListing.API.Core.Models.Hotel;
using HotelListing.Entities.DTO;
using HotelListing.Entities.Enums;
using HotelListingEntities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Validation
{
    public class HotelsValidation : BaseValidator<HotelDto, long>, IHotelsValidation
    {
        public override List<ValidationMessageDto> Validate(HotelDto hotel)
        {
            var errors = new List<ValidationMessageDto>();

            // Basic Validations
            if (string.IsNullOrWhiteSpace(hotel.Address))
            {
                errors.Add(GetValidationMessage(ValidationCode.ItemNotFound));
            }
        


            // DB Validations


            System.Linq.Expressions.Expression<Func<Hotel, bool>> existsFilter;
            existsFilter = c => c.Address == hotel.Address;

            if (hotel.Id > 0)
            {
                //if (!_standCCTVRepository.Any(c => c.Id == StandCCTVDTO.ID))
                //{
                //    errors.Add(GetValidationMessage(ValidationCode.ItemNotFound));
                //}

                //existsFilter = c => c.Ip == StandCCTVDTO.IP && c.Id != StandCCTVDTO.ID;
            }

            //if (_standCCTVRepository.Any(c => c.Ip == StandCCTVDTO.IP && c.Id != StandCCTVDTO.ID))
            //{
            //    errors.Add(GetValidationMessage(ValidationCode.IPalreadyexists));
            //}



        

            return errors;
        }

        public override List<ValidationMessageDto> ValidateDeletion(long id)
        {
            var errors = new List<ValidationMessageDto>();
            if (id <= 0)
            {
                errors.Add(GetValidationMessage(ValidationCode.ItemNotFound));
            }
            else
            {
                //if (!_standCCTVRepository.Any(c => c.Id == id))
                //{
                //    errors.Add(GetValidationMessage(ValidationCode.ItemNotFound));
                //}
            }

            return errors;
        }
    }
}
