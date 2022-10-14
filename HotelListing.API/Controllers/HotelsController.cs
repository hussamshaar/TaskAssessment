using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Core.Contracts;
using AutoMapper;
using HotelListing.API.Core.Models.Hotel;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Core.Models.Country;
using HotelListing.API.Core.Models;
using HotelListing.API.Core.Repository;
using HotelListingEntities.DBModels;
using HotelListing.Services.Services;
using HotelListing.Services.IServices;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository _hotelsRepository;

        private readonly IMapper _mapper;


        private readonly IHotelsService _hotelsService;

        public HotelsController(IHotelsRepository hotelsRepository, IMapper mapper, HotelsService hotelsService)
        {
            this._hotelsRepository = hotelsRepository;
            this._mapper = mapper;
            _hotelsService = hotelsService;
        }

        // GET: api/Hotels
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await _hotelsService.GetAllAsync();

        //  await  _hotelsService.GetAll();
            return Ok(hotels);
        }


        // GET: api/Hotels
        [HttpGet("GetHotelsSearch")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsSearch(Hotel hotel)
        {
            var hotels = await _hotelsRepository.GetSearchAsync(hotel);
            return Ok(hotels);
        }


        // GET: api/Hotels/?StartIndex=0&pagesize=25&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<HotelDto>>> GetPagedHotels([FromQuery] QueryParameters queryParameters)
{
            var pagedHotelsResult = await _hotelsRepository.GetAllAsync<HotelDto>(queryParameters);
            return Ok(pagedHotelsResult);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelsService.GetAsync(id);
            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel( HotelDto hotelDto)
        {
            try
            {
                await _hotelsService.Update(hotelDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(hotelDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDto>> PostHotel(CreateHotelDto hotelDto)
        {
            var hotel = await _hotelsService.AddAsync(hotelDto);
            return Ok(hotel);//CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(long id)
        {
            await _hotelsService.Delete(id); 
            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsService.HotelExists(id);
        }
    }
}
