using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Scripture_Journal.Models
{
    public class Entry
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        [Display(Name = "Verse Range")]
        public string VerseRange { get; set; }
        public string Notes { get; set; }
    }
}
