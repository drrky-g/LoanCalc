namespace LoanCalc.Controllers {
    using LoanCalc.Models;
    using System.Web.Mvc;
    public class LoanController : Controller {
        // Main App
        public ActionResult App() { return View(); }
        // Api Example
        public ActionResult Example() { return View(); }
        // Code Preview
        public ActionResult Code() { return PartialView(); }
        // Table Partial
        public ActionResult Table(LoanParams loan) {
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