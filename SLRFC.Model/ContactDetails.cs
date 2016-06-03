namespace SLRFC.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ContactDetails
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactDetailsId { get; set; }

        public string ContactTelephone { get; set; }

        [Required]
        public Address Address { get; set;  }
    }
}