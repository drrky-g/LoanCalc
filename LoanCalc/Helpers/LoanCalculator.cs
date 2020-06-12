using LoanCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanCalc.Helpers {
    public class LoanCalculator {
        //1- calculate monthly payment
        //2- convert annual to monthly rate
        //3- 
        public double TotalPayment { get; set; }
        public double TotalMonthlyPayment { get; set; }
        public double StartingPrincipal { get; set; }
        public double RemainingBalance { get; set; }
        public double TotalInterestPaid { get; set; }
        public double MonthlyInterestRate { get; set; }
        public int TermLengthMonths { get; set; }
        public IList<PaymentSummary> PaymentSchedule { get; set; }
        public void Calculate() {
            //for each month... 
            //1: take remaining balance
            //2: 
            for(int i = 1; i <= TermLengthMonths; i++) {
                PaymentSchedule.Add(new PaymentSummary {

                });
            }
        }

    }
}