using RpgHBAnnals.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Model.Weapon
{
    public class WeaponListItem
    {
        public int WeaponId { get; set; }
        public int GameId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public WeaponType Type { get; set; }
        public string Name { get; set; }
    }
}
