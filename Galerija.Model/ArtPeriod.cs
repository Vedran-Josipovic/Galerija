using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galerija.Model
{
    public class ArtPeriod : NamedEntity
    {
        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
