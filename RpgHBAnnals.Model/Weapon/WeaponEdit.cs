using RpgHBAnnals.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Model.Weapon
{
    public class WeaponEdit
    {
        
        public int WeaponId { get; set; }
        public WeaponType Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Properties { get; set; }
    }
}
