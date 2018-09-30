using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationPractice.Entities
{
    [Table("Location")]
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Location")]
        public string LocationText { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Country Country { get; set; }

        public int? CountryId { get; set; }
    }
}