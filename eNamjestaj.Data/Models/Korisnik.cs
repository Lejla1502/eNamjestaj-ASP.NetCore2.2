using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Korisnik
    {
        
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string TwoFactorUniqueKey { get; set; }

        public int OpstinaId { get; set; }
        public virtual Opstina Opstina { get; set; }
        
        public int UlogaId { get; set; }
        public virtual Uloga Uloga { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string LozinkaHash { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string LozinkaSalt { get; set; }
    }
}
