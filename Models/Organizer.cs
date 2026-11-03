using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore02.Models
{
    [Table("EventOrganizers")]
    public class Organizer
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string name { get; set; }

        [MaxLength(150)]
        public string CompanyName { get; set; }

        public bool IsVerifaied { get; set; }

        public List<Event> Events { get; set; }

        public OrganizerProfile Profile { get; set; }
    }
}
