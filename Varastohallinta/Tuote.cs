using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Varastohallinta
{
    public class Tuote
    {
        [Key]
        public int? id { get; set; }
        public string? tuoteNimi { get; set; }
        public int? tuotenHinta { get; set; }
        public int? varastoSaldo { get; set; }

    }
}
