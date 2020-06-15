namespace LoanCalc.Controllers {
    using LoanCalc.Interfaces;
    using LoanCalc.Models.LoanModels;
    using System.Web.Mvc;
    public class LoanController : Controller, ILoanController {
        public ViewResult App() { 
            return View();
        }
        public PartialViewResult Form(bool isStart = false) {
            return PartialView(isStart);
        }
        public PartialViewResult Table(double amount, int months, double rate) {
            LoanParams loan = new LoanParams {
                Amount = amount,
                Months = months,
                Rate = rate / 100
            };
            return PartialView(loan.GetTableData());
        }
        public JsonResult Chart(double amount, int months, double rate) {
            LoanParams loan = new LoanParams {
                Amount = amount,
                Months = months,
                Rate = rate / 100
            };
            return Json(loan.GetChartData(), 
                JsonRequestBehavior.AllowGet);
        }
    }
}