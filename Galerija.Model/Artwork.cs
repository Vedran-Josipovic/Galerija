using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Galerija.Model
{
    public class Artwork : NamedEntity
    {
        public int YearCompleted { get; set; }

        [ForeignKey(nameof(ArtPeriod))]
        public int PeriodID { get; set; }
        public virtual ArtPeriod ArtPeriod { get; set; }


        [ForeignKey(nameof(Artist))]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }


        public virtual ICollection<Attachment>? Images { get; set; }
    }
}
