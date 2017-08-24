using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UoW_Sample.Request
{
    public class AddressDto
    {
        public string CityCode { get; set; }
        public string DistrictCode { get; set; }
        public string Description { get; set; }
    }
}