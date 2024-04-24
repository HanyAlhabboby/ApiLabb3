using System.ComponentModel.DataAnnotations;

namespace ApiLabb3.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int PhoneNumber { get; set; }

        public List<Interest> Interests { get; set; } = new List<Interest>();


    }
}
