using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebAPI.Entities
{
    public class Treatment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TreatmentName { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public Guid DoctorId { get; set; }
        
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        public bool Suspended { get; set; }
    }
}
