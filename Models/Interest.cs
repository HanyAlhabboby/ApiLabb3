using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLabb3.Models
{
    public class Interest
    {
        [Key]

        public int InterestId { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }

        [ForeignKey("Person")]

        public int FkPersonId { get; set; }

        public Person? Person { get; set; }

        public ICollection<Link>? Links { get; set; }
    }
}
