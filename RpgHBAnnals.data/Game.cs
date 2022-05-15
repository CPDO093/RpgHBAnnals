using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Edition { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        //relationship

        public virtual List<Npc> Npc { get; set; }

        public virtual List<Weapon> Weapon { get; set; }
    }
}
