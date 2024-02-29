using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOT.DOMEN.Entities.DTOS
{
    public class RegisterLogin
    {
        public string ?Name { get; set; }
        public string ?Email { get; set; }
        public string Password { get; set; }
        public string ConiformPassword { get; set; }
        public string Login { get; set; }
    }
}
