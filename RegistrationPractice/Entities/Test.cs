using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using RegistrationPractice.Models;

namespace RegistrationPractice.Entities
{
    public class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Lost Item/Found Item")]
        public bool LostOrFoundItem { get; set; }


        [Required]
        [DisplayName("Please return for free!")]
        public bool NoReward { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Reward { get; set; }

    }
}