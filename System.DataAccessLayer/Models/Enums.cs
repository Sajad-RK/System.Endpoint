using System;
using System.Collections.Generic;
using System.Text;

namespace System.DataAccessLayer.Models
{
    public class Enums
    {
        public enum UserType
        {
            Developer = 1,
            FullAdmin = 2,
            Admin = 3,
            Operator = 4,
        }
        public enum ServiceType
        {
            Flight = 1,
            Hotel = 2,
            Bus = 3
        }
    }
}
