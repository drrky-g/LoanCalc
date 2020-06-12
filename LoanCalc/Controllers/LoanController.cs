using LoanCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanCalc.Controllers {
    public class LoanController : Controller {
        // Main App
        public ActionResult Index() { return View(); }
        // Api Example
        public ActionResult Example() { return View(); }
        // Table Partial
        public ActionResult Calculate(LoanParams loan) {
            LoanTable table = new LoanTable(loan);
            return PartialView(table);
        }
        // Json Endpoint
        public JsonResult AsJson(int amount, int months, int rate) {
            LoanParams loan = new LoanParams {
                InterestRate = rate,
                Principal = amount,
                TermLengthMonths = months
            };
            return Json(new LoanTable(loan), JsonRequestBehavior.AllowGet);
        }
    }
}