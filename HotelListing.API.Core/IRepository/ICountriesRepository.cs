using HotelListing.API.Core.Models.Country;
using HotelListingEntities.DBModels;

namespace HotelListing.API.Core.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<CountryDto> GetDetails(int id);
    }
}
