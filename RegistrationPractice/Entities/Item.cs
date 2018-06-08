using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using RegistrationPractice.Models;

namespace RegistrationPractice.Entities
{

    [Table("Item")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        //[Required]
        public string Description { get; set; }

        //[MaxLength(15)]
        //[Required]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual DateTime? CreationDate { get; set; }

        public string EmailRelayAddress { get; set; }

        public int? Reward { get; set; }

        public string AdditionalNotes { get; set; }

        public int? Visits { get; set; }

        public bool? Returned { get; set; }

        public int? ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string imageURL { get; set; }

        public string imageTitle { get; set; }

        [Display(Name = "Display profile Image")]
        public bool? DisplayItem { get; set; }


    }
}