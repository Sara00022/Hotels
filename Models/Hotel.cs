using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        [Required]
        [StringLength(25)]
        public string Email { get; set; }
        [Required]
        [StringLength(25)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Image { get; set; }
    } 
}
