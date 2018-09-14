﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Entities
{
    [Table("CategoryPostType")]
    public class CategoryPostType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }



        [DisplayName("Post Type")]
        public int? PostTypeID { get; set; }
        public virtual PostType PostType { get; set; }
    }
}