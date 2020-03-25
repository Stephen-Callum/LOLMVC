using System;
using System.Collections.Generic;

namespace LOLMVC
{
    public partial class ChampStat
    {
        public int StatId { get; set; }
        public int? ChampId { get; set; }
        public decimal? WinRate { get; set; }
        public decimal? PickRate { get; set; }
        public decimal? BanRate { get; set; }
        public string Tier { get; set; }
        public string LanePlayed { get; set; }

        public virtual Champion Champ { get; set; }
    }
}
