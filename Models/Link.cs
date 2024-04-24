using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLabb3.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }

        public string LinkInfo { get; set; }

        [ForeignKey("Interest")]
        public int FkInterestId { get; set; }
        public Interest? Interest { get; set; }

    }
}
