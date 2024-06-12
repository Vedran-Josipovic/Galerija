using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galerija.Model
{
    public class Exhibition : NamedEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        [ForeignKey(nameof(Museum))]
        public int MuseumID { get; set; }
        public virtual Museum Museum { get; set; }

        public virtual ICollection<Artwork>? Artworks { get; set; }
    }
}
