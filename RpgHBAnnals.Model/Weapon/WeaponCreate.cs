using RpgHBAnnals.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.Model.Weapon
{
    public class WeaponCreate
    {
      

        [Required]
        [Display(Name = "Compatable game ")]
        public int GameId { get; set; }
        [Required]
        public WeaponType Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Damage { get; set; }
        [Required]
        public string Properties { get; set; }
    }
}
