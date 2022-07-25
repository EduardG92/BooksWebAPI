using System.ComponentModel.DataAnnotations;

namespace BooksWebAPI.Entities
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public bool Insured { get; set; }

        public bool? Deleted { get; set; }



    }
}
