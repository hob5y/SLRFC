namespace SLRFC.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player : Member
    {
        [Required]
        public bool IsActive { get; set; }

        public string Position { get; set; }

        public List<Availability> Availabilities { get; set; }
    }
}
