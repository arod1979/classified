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

    [Table("Item")]
    public class Item
    {
        //necessary fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Description { get; set; }

        [DisplayName("What Happened")]
        public int? PostTypeID { get; set; }
        public virtual PostType PostType { get; set; }

        [DisplayName("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        [Required]
        [DisplayName("Lost Location")]
        public string LostLocation { get; set; }

        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]

        [Range(20, 10000)]
        [DisplayName("Item Reward")]
        //[DataType(dataType: DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public decimal ItemReward { get; set; }

        [Required]
        [DisplayName("What Day Did You Find it")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime FoundDate { get; set; } = System.DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime CreationDate { get; set; } = System.DateTime.Now;

        [Required]
        [DisplayName("Category")]
        public int? CategoryID { get; set; }


        public virtual Category Category { get; set; }
        public string CategoryText { get; set; }

        [Required]
        public string AdditionalNotes { get; set; }

        public int Visits { get; set; }

        public bool Returned { get; set; }



        public string EmailRelayAddress { get; set; }


        [Required]
        public string OwnerUserEmail { get; set; }

        [Required]
        public string UserId { get; set; }

        [DisplayName("Image")]
        public string imageURL { get; set; }

        public string imageTitle { get; set; }

        [Display(Name = "Display profile Image")]
        public bool? HideItem { get; set; }


        public string lostcheckbox { get; set; }

        public string foundcheckbox { get; set; }

        public string stolencheckbox { get; set; }

        public string anonymoustipcheckbox { get; set; }

    }
}