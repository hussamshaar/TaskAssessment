using HotelListing.API.Core.Models;
using HotelListing.API.Core.Models.Country;
using HotelListing.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.IServices
{
    public interface ICountriesService
    {
        Task<BusinessResultSet<List<GetCountryDto>>> GetAllAsync();
        Task<BusinessResultSet<CountryDto>> GetDetails(int id);

        Task<BusinessResultSet<bool>> UpdateAsync(UpdateCountryDto updateCountryDto);

        Task<BusinessResultSet<bool>> AddAsync(CreateCountryDto createCountryDto);

        Task<BusinessResultSet<bool>> DeleteAsync(int id);
    }
}
