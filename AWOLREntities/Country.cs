using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace RegistrationPractice.Entities
{
    [Table("Country")]
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("RegionAbbreviation")]
        public string RegionAbbreviation { get; set; }

        [DisplayName("RegionText")]
        public string RegionText { get; set; }

        [DisplayName("CountryText")]
        public string CountryText { get; set; }




    }
}