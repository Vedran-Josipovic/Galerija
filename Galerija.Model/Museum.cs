using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galerija.Model
{
    public class Museum : NamedEntity
    {
        [Required]
        [MinLength(5, ErrorMessage = "Address must be at least 5 characters long")]
        public string Address { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; }

        public virtual ICollection<Artwork>? Artworks { get; set; }
        public virtual ICollection<Exhibition>? Exhibitions { get; set; }
    }
}
