using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanCalc.Controllers {
    public class CodeController : Controller {
        public ActionResult Loan() { return PartialView(); }
    }
}