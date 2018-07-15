using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistrationPractice.Entities;

namespace RegistrationPractice.Classes.ViewModels
{
    public class VMCityItems
    {
        public List<Item> LostItems { get; set; }
        public List<Item> FoundItems { get; set; }
        public List<Item> StolenItems { get; set; }
    }
}