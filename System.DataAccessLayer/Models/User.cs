﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.DataAccessLayer.Models.Enums;

namespace System.DataAccessLayer.Models
{
    public class User : BaseInfoModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NationId { get; set; }
        public UserType UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid ClientId { get; set; }

        public Client Client { get; set; }
    }
}
