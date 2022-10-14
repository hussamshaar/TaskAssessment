using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Entities.Enums
{
    public enum Language : int
    {
        Arabic = 1,
        English = 2
    }

    public enum ValidationCode : int
    {
        GeneralError = 0,
        TitleRequired = 1,
        ItemNotFound = 2,
        ItemAlreadyExisting = 3,
    }
}
