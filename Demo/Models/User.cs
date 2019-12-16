using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models {
    public class User {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}