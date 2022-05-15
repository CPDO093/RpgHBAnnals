using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Model.Npc
{
    public class NpcListItem
    {
       
        public int NpcId { get; set; }
        public int GameId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
    }
}
