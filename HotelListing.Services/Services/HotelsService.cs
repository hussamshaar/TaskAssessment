using HotelListing.API.Core.Contracts;
using HotelListing.API.Core.Models.Hotel;
using HotelListing.API.Core.Repository;
using HotelListing.Entities.DTO;
using HotelListing.Services.IServices;
using HotelListing.Services.Mapper;
using HotelListing.Validation;
using HotelListingEntities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.Services
{
    public class HotelsService : IHotelsService
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IHotelsValidation _hotelsValidation;
        public HotelsService(IHotelsRepository hotelsRepository, IHotelsValidation hotelsValidation)
        {
            _hotelsRepository = hotelsRepository;
            _hotelsValidation = hotelsValidation;


        }
        public async Task<BusinessResultSet<List<HotelDto>>> GetAllAsync()
        {

            var HotelList = (await _hotelsRepository.GetAllAsync()).Select(MapperHotel.MapHotel).ToList();
            var result = new BusinessResultSet<List<HotelDto>>(HotelList);
            return result;

        }

        public async Task<BusinessResultSet<List<HotelDto>>> GetSearchAsync(Hotel hotel)
        {

            var HotelList = (await _hotelsRepository.GetSearchAsync(hotel)).Select(MapperHotel.MapHotel).ToList();
            var result = new BusinessResultSet<List<HotelDto>>(HotelList);
            return result;

        }

        public async Task<BusinessResultSet<HotelDto>> GetAsync(int id)
        {
            var hotels = MapperHotel.MapHotel(await _hotelsRepository.GetAsync(id));
            var result = new BusinessResultSet<HotelDto>(hotels);
            return result;

        }

        public async Task<BusinessResultSet<bool>> Update(HotelDto model)
        {
            BusinessResultSet<bool> result;
            var hotels = await _hotelsRepository.GetAsync(model.Id);
            var hotelsUpdate = MapperHotel.ToModel(model, hotels);
            await _hotelsRepository.UpdateAsync(hotelsUpdate);
            result = new BusinessResultSet<bool>(true);

            return result;
        }

        public async Task<BusinessResultSet<bool>> AddAsync(CreateHotelDto hotel)
        {
            BusinessResultSet<bool> result;

            var model = MapperHotel.ToModelAdd(hotel);
            await _hotelsRepository.AddAsync(model);

            result = new BusinessResultSet<bool>(true);

            return result;
        }

        public  async Task<BusinessResultSet<bool>> Delete(long id)
        {
            BusinessResultSet<bool> result;
            var validations = _hotelsValidation.ValidateDeletion(id);
            if (validations.Count > 0)
            {
                result = new BusinessResultSet<bool>(validations);
            }
            else
            {
                await _hotelsRepository.DeleteAsync(Convert.ToInt32(id));

                 result = new BusinessResultSet<bool>(true);
            }

            return result;
        }

        public async Task<bool> HotelExists(int id)
        {


          var  result= await _hotelsRepository.Exists(id);
            
            return result;
        }
    }
}
