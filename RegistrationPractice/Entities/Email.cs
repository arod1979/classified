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
    [Table("Email")]
    public class Email
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int postid { get; set; }

        [Required]
        public string emailbody { get; set; }

        [Required]
        [DisplayName("From Address")]
        public string fromaddress { get; set; }



        [Required]
        [DisplayName("To Address")]
        public string toaddress { get; set; }

        public string subject { get; set; }

        [DisplayName("BCC Address")]
        public string[] bccaddress { get; set; }

        [DisplayName("APIEmailID")]
        public int APIEmailId { get; set; }
        public virtual Location Location { get; set; }

        [DisplayName("APIThreadID")]
        public int APIThreadId { get; set; }

        public virtual int PosterUserId { get; set; }

        public virtual int ResponderUserId { get; set; }



    }
}