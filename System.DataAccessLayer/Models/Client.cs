using System;
using System.Collections.Generic;
using System.Text;

namespace System.DataAccessLayer.Models
{
    public class Client : BaseInfoModel
    {
        public string Name { get; set; }
        //public Guid AdminId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Wallet_NO { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
