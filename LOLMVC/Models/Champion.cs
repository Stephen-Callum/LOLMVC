using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LOLMVC
{
    public partial class Champion
    {
        public Champion()
        {
            ChampStat = new HashSet<ChampStat>();
        }

        public int ChampId { get; set; }
        public string ChampName { get; set; }
        public string ChampRole { get; set; }
        public int? ChampPrice { get; set; }
        public string ChampResource { get; set; }
        public string Lore { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ChampReleaseDate { get; set; }
        public string ChampImage { get; set; }

        public virtual ICollection<ChampStat> ChampStat { get; set; }
    }
}
