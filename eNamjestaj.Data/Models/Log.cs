using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace eNamjestaj.Data.Models
{
    public class Log
    {
       
       public int Id { get; set; }
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public string AreaAccessed { get; set; }
        public DateTime Timestamp { get; set; }

       // public Log() { }
    }
}
