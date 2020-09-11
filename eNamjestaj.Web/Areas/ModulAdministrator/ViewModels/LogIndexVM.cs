using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulAdministrator.ViewModels
{
    public class LogIndexVM
    {
        public List<Audit> Audits { get; set; }
        public class Audit
        {
            public string Username { get; set; }
            public string IPAddress { get; set; }
            public string AreaAccessed { get; set; }
            public DateTime Timestamp { get; set; }

        }
    }
}
