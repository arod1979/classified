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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("What Happened?")]
        public bool LostOrFoundItem { get; set; }

        
        

        [Required]
        [DisplayName("Please return for free!")]
        public bool NoReward { get; set; }


        [Required]
        [DisplayName("Item Reward")]
        [DataType(dataType: DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal? ItemReward { get; set; }


        [MaxLength(25)]
        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("What Happened")]
        public int PostTypeID { get; set; }
        public virtual PostType PostType { get; set; }

        [Required]
        [DisplayName("What Day Did You Find it")]
        public virtual DateTime FoundDate { get; set; } = System.DateTime.Now;

        [DisplayName("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual DateTime CreationDate { get; set; } = System.DateTime.Now;

        public string EmailRelayAddress { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string AdditionalNotes { get; set; }

        public int Visits { get; set; }

        public bool Returned { get; set; }

        public string OwnerUserEmail { get; set; }

        //public virtual ApplicationUser ApplicationUser { get; set; }

        //public string ApplicationUserId { get; set; }

        [DisplayName("Image")]
        public string imageURL { get; set; }

        public string imageTitle { get; set; }

        [Display(Name = "Display profile Image")]
        public bool? HideItem { get; set; }

        


    }
}