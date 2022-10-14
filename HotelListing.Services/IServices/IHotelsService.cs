using HotelListing.API.Core.Models.Country;
using HotelListing.API.Core.Models.Hotel;
using HotelListing.Entities.DTO;
using HotelListingEntities.DBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.IServices
{
    public interface IHotelsService
    {
        Task<BusinessResultSet<List<HotelDto>>> GetAllAsync();

        Task<BusinessResultSet<List<HotelDto>>> GetSearchAsync(Hotel hotel);
        Task<BusinessResultSet<HotelDto>> GetAsync(int id);

        Task<BusinessResultSet<bool>> Update(HotelDto model);
        Task<BusinessResultSet<bool>> AddAsync(CreateHotelDto hotel);

        Task<BusinessResultSet<bool>> Delete(long id);
        Task<bool> HotelExists(int id);





    }
}
