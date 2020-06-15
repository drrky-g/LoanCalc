namespace LoanCalc.Controllers {
    using LoanCalc.Interfaces;
    using LoanCalc.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    public class LoanController : Controller, ILoanController {
        public LoanController() { loan = null; }
        internal class ChartData {
            public ChartData() { }
            public string[] labels { get; set; }
            public double[] lineData { get; set; }
            public double[] barData { get; set; }
        }
        public LoanParams loan { get; set; }
        public ViewResult App() { 
            return View();
        }
        public PartialViewResult Form(bool isStart = false) {
            return PartialView(isStart);
        }
        public PartialViewResult Table(double amount, int months, double rate) {
            loan = new LoanParams {
                InterestRate = rate,
                Principal = amount,
                TermLengthMonths = months
            };
            return PartialView(new LoanTable(loan));
        }
        public JsonResult Chart(double amount, int months, double rate) {
            loan = new LoanParams {
                InterestRate = rate,
                Principal = amount,
                TermLengthMonths = months
            };
            LoanTable table = new LoanTable(loan);
            IList<string> chartLabels = new List<string>(loan.TermLengthMonths);
            DateTime time = DateTime.Now;
            for (int i = 0; i < loan.TermLengthMonths; i++) {
                chartLabels.Add(time.AddMonths(i).ToString("MMM"));
            }
            return Json(new ChartData {
                labels = chartLabels.ToArray(),
                lineData = table.TableData.Select(t => t.PrinciplePaymentAmount).ToArray(),
                barData = table.TableData.Select(t => t.InterestPaymentAmount).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}