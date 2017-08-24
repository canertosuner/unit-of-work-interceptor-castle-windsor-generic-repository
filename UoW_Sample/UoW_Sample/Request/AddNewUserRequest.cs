using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UoW_Sample.Request
{
    public class AddNewUserRequest
    {
        public UserDto User { get; set; }
        public AddressDto Address { get; set; }
    }
}