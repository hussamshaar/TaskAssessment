using HotelListing.API.Core.Models.Country;
using HotelListing.API.Core.Models.Hotel;
using HotelListingEntities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Mapper
{
    internal class MapperCountry
    {

        public static GetCountryDto MapCountry(Country model)
        {
            if (model == null)
                return null;


            return new GetCountryDto
            {

                Name = model.Name,
               Id= model.Id,
               ShortName =model.ShortName,
            };

        }

        public static Country ToModelAdd(CreateCountryDto dto, Country model = null)
        {
            if (dto == null)
                return null;

            model = model ?? new Country();

       
            model.Name = dto.Name;
            model.ShortName = dto.ShortName;
       
            return model;
        }
        public static Country ToModel(UpdateCountryDto dto, Country model = null)
        {
            if (dto == null)
                return null;

            model = model ?? new Country();

            model.ShortName = dto.ShortName;
            model.Name = dto.Name;
            model.Id = dto.Id ;
           




            return model;
        }
    }
}
