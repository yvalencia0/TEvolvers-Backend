using System.ComponentModel.DataAnnotations;

namespace TEvolvers.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required]
        public DateTime datetime { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public int age { get; set; }
    }
}
    