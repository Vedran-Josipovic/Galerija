using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galerija.Model
{
    public class Artist
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        public string LastName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Biography must be at least 10 characters long")]
        public string Biography { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Artwork>? Artworks { get; set; }
    }
}
