using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Entities
{

    [Table("Totals")]
    public class Totals
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Lost { get; set; }
        public string Found { get; set; }
        public string Stolen { get; set; }

    }

}