using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HotelListingEntities.DBModels;
using Newtonsoft.Json;

namespace HotelListing.Test.Helpers
{
    public class DatabaseSeeder
    {
        private readonly HotelListingDbContext _context;

        public DatabaseSeeder(HotelListingDbContext context)
        {
            _context = context;
        }

        public async Task<int> SeedBookEntitiesFromJson(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"Value of {filePath} must be supplied to {nameof(SeedBookEntitiesFromJson)}");
            }
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"The file { filePath} does not exist");
            }
            var dataSet = await File.ReadAllTextAsync(filePath);
            var seedData = JsonConvert.DeserializeObject<List<Hotel>>(dataSet);

            // ensure that we only get the distinct books (based on their name)
            var distinctSeedData = seedData.GroupBy(b => b.Name).Select(b => b.First());

            _context.Hotels.AddRange(distinctSeedData);
            return await _context.SaveChangesAsync();
        }
    }
}