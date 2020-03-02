using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.ViewModels
{
    public class LoginVM
    {
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool ZapamtiPassword { get; set; }
    }
}
