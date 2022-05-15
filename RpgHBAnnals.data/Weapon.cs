using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.data
{
    public enum WeaponType { SimpleMelee = 1, SimpleRanged, MartialMelee, MartialRanged, Artificat = 5 }
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

       
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        [Required]
        [Display(Name = "Created on ")]
        public DateTimeOffset CreatedUtc { get; set; }

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
