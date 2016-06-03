namespace SLRFC.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Availability
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvailabilityId { get; set; }

        [Required]
        public Event Event { get; set; }

        [Required]
        public AvailabilityFlag AvailabilityFlag { get; set; }
    }
}