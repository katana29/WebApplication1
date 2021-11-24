using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Polaganje")]
    public class Polaganje
    {
        [Key]
        public string PolaganjeID { get; set;  }

        [Display(Name = "Dobijena ocena")]
        public int ocena { get; set; }
        
        [Display(Name = "Datum polaganja")]
        [DataType(DataType.Date)]
        public DateTime datum { get; set; }

        public string StudentID { get; set; }
        public Student Student { get; set; }

        public string PredmetID { get; set; }
        public Predmet Predmet { get; set; }

    }
}