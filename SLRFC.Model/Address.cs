namespace SLRFC.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Required]
        [Key]
        public int AddressId { get; set; }

        public string HouseNameOrNumber { get; set; }

        public string StreetName1 { get; set; }

        public string StreetName2 { get; set; }

        public string TownOrCity { get; set; }

        public string County { get; set; }

        public string Postcode { get; set; }
    }
}