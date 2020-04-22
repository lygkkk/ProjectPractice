using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEF.Abstract.Models
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
