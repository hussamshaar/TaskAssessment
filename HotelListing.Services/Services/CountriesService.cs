using HotelListing.API.Core.Contracts;
using HotelListing.API.Core.Models;
using HotelListing.API.Core.Models.Country;
using HotelListing.API.Core.Models.Hotel;
using HotelListing.API.Core.Repository;
using HotelListing.Entities.DTO;
using HotelListing.Services.IServices;
using HotelListing.Services.Mapper;
using HotelListingEntities.DBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository _countriesRepository;
        public CountriesService(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }
        public async Task<BusinessResultSet<List<GetCountryDto>>> GetAllAsync()
        {

            var CountrylList = (await _countriesRepository.GetAllAsync()).Select(MapperCountry.MapCountry).ToList();
            var result = new BusinessResultSet<List<GetCountryDto>>(CountrylList);
            return result;

        }
        public async Task<BusinessResultSet<CountryDto>> GetDetails(int id)
        {
            var country = await _countriesRepository.GetDetails(id);
            var result = new BusinessResultSet<CountryDto>(country);
            return result;
        }

        public async Task<BusinessResultSet<bool>> UpdateAsync(UpdateCountryDto updateCountryDto)
        {
            BusinessResultSet<bool> result;
            var country = await _countriesRepository.GetAsync(updateCountryDto.Id);
            var countryUpdate = MapperCountry.ToModel(updateCountryDto, country);
            await _countriesRepository.UpdateAsync(countryUpdate);
            result = new BusinessResultSet<bool>(true);

            return result;
        }
        public async Task<BusinessResultSet<bool>> AddAsync(CreateCountryDto createCountryDto)
        {
            BusinessResultSet<bool> result;

            var model = MapperCountry.ToModelAdd(createCountryDto);
            await _countriesRepository.AddAsync(model);

            result = new BusinessResultSet<bool>(true);

            return result;
        }
        public async Task<BusinessResultSet<bool>> DeleteAsync(int id)
        {
            BusinessResultSet<bool> result;
         
                await _countriesRepository.DeleteAsync(id);

                result = new BusinessResultSet<bool>(true);
            

            return result;
        }
    }
}
