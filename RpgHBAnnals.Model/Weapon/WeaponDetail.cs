using RpgHBAnnals.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Model.Weapon
{
    public class WeaponDetail
    {
       
        public int WeaponId { get; set; }
        public Guid CreatorId { get; set; }
        public int GameId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public WeaponType Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Properties { get; set; }
    }
}
