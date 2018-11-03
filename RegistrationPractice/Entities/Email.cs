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


    [Table("EmailRecipients")]
    public class EmailRecipients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string emailbody { get; set; }

        [Required]
        public string itemdescription { get; set; }

        [Required]
        public int IdItem { get; set; }

        [Required]
        public string pid { get; set; }

        [Required]
        public string bid { get; set; }

        [Required]
        public string pidrealemailaddress { get; set; }

        [Required]
        public string bidrealemailaddress { get; set; }

        public string pidfakeemailaddress { get; set; }
        public string bidfakeemailaddress { get; set; }

        public bool lostcheckbox { get; set; }

        public bool foundcheckbox { get; set; }

        public bool stolencheckbox { get; set; }

        public bool anonymoustipcheckbox { get; set; }


        public DateTime DateCreated { get; set; } = System.DateTime.Now;

    }

    [Table("Email")]
    public class Email
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("From Address")]
        public string fromaddress { get; set; }

        [DisplayName("To Address")]
        public string toaddress { get; set; }

        [Required]
        public int IdItem { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public string emailbody { get; set; }

        public string subject { get; set; }

        public DateTime DateCreated { get; set; } = System.DateTime.Now;

        [DisplayName("EmailID")]
        public int EmailId { get; set; }

        [DisplayName("APIThreadID")]
        public int APIThreadId { get; set; }
    }

    [Table("HistoryID")]
    public class HistoryID
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("HistoryID")]
        public long History { get; set; }

        public DateTime DateCreated { get; set; } = System.DateTime.Now;

    }

    [Table("FakeEmail")]
    public class FakeEmail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("FakeEmail")]
        public string FakeEmailChars { get; set; }

        public DateTime DateCreated { get; set; } = System.DateTime.Now;

    }
}