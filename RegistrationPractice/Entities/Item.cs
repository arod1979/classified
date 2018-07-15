﻿using System;
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
        [DisplayName("Item Reward")]
        [DataType(dataType: DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal ItemReward { get; set; }
        
        [Required]
        [DisplayName("What Day Did You Find it")]
        public virtual DateTime FoundDate { get; set; } = System.DateTime.Now;

        public virtual DateTime CreationDate { get; set; } = System.DateTime.Now;

        [DisplayName("Category")]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string AdditionalNotes { get; set; }

        public int Visits { get; set; }

        public bool Returned { get; set; }


       

        public string EmailRelayAddress { get; set; }

        

        public string OwnerUserEmail { get; set; }

       

        [DisplayName("Image")]
        public string imageURL { get; set; }

        public string imageTitle { get; set; }

        [Display(Name = "Display profile Image")]
        public bool? HideItem { get; set; }

        


    }
}