using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Model.Npc
{
    public class NpcCreate
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Notes { get; set; }
    }
}
