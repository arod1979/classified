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

        public double Lost { get; set; }
        public double Found { get; set; }
        public double Stolen { get; set; }

    }

}