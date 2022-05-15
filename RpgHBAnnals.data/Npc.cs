using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHBAnnals.data
{
    public class Npc
    {
        [Key]
        public int NpcId { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        [Required]
        [Display(Name = "Created on ")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}
