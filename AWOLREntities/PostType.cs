using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationPractice.Entities
{
    [Table("PostType")]
    public class PostType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("What Happened?")]
        public string PostTypeText { get; set; }

        //public ICollection<Item> Items { get; set; }
    }
}