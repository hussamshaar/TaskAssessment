using System.Collections.Generic;
using Moq;
using Xunit;
using System.IO;
using System;
using HotelListing.Test.Helpers;
using HotelListingEntities.DBModels;

namespace HotelListing.Test
{
    public class DatabaseSeederTests
    {
        [Fact]
        public async void DbSeeder_SeedBookData_NoDataSupplied_ShouldThrowException()
        {
            // Arrange
            var hotelList = new List<Hotel>();
            var mockBookSet = DbSetHelpers.GetQueryableDbSet(hotelList);
            var mockset = new Mock<HotelListingDbContext>();
            mockset.Setup(m => m.Hotels).Returns(mockBookSet.Object);

            // Act & Assert
            var dbSeeder = new DatabaseSeeder(mockset.Object);
            var argEx = await Assert.ThrowsAsync<ArgumentException>(() =>
                dbSeeder.SeedBookEntitiesFromJson(string.Empty));
        }

    }
}