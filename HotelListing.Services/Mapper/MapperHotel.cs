using HotelListing.API.Core.Models.Hotel;
using HotelListingEntities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Mapper
{
    public class MapperHotel
    {

        public static HotelDto MapHotel(Hotel model)
        {
            if (model == null)
                return null;
         

            return new HotelDto
            {
       
                Name = model.Name,
                Address =model.Address,
                CountryId= model.CountryId,
                Rating =model.Rating,
            };

        }

        public static Hotel ToModel(HotelDto dto, Hotel model = null)
        {
            if (dto == null)
                return null;

            model = model ?? new Hotel();

            model.Address = dto.Address;
            model.Name = dto.Name;
            model.Rating = dto.Rating ?? 0;
            model.CountryId = dto.CountryId;




            return model;
        }

        public static Hotel ToModelAdd(CreateHotelDto dto, Hotel model = null)
        {
            if (dto == null)
                return null;

            model = model ?? new Hotel();

            model.Address = dto.Address;
            model.Name = dto.Name;
            model.Rating = dto.Rating ?? 0;
            model.CountryId = dto.CountryId;




            return model;
        }
    }
}
