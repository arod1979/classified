using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationPractice.Controllers.aspnetmvc
{
    public class StackController : Controller
    {

        public class CreateRMAVM
        {
            public List<vare> vares { get; set; }
            public string CustomerName { get; set; }

            public class vare
            {

                public vare()
                {

                }

                public vare(/*string CustomerName*/ string ProductName, string SerialNumber, string Qty)
                {
                }

                public string CustomerName { get; set; }
                public string ProductName { get; set; }
                public string SerialNumber { get; set; }
                public string Qty { get; set; }
            }
        }


        // GET: Stack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stack/Create
        [AllowAnonymous]
        [HttpPost]
        public JsonResult Create(CreateRMAVM vm)
        {
            try
            {
                if (vm.CustomerName != null && vm.vares != null)
                {
                    vm.vares.Select(c => { c.CustomerName = vm.CustomerName; return c; }).ToList();
                }

                return null;
            }
            catch
            {
                return null;
            }
        }


    }
}
