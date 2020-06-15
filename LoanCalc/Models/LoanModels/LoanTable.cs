namespace LoanCalc.Models.LoanModels {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LoanTable : LoanParams {
        public LoanTable(double amount, int months, double rate) {
            Amount = Math.Round(amount,2);
            Months = months;
            Rate = rate / 100;
            TableData = new List<PaymentSummary>();

            double payment = (amount * (Rate / 12) * (Math.Pow(1 + Rate / 12, Months))) / (Math.Pow(1 + (Rate / 12), Months) - 1);

            double startingBalance = amount;
            double endingBalance = amount;
            double totalInterestPaid = 0.00;

            for (int month = 1; month <= Months; month++) {
                double interestCharge = rate / 12 * startingBalance;
                totalInterestPaid += interestCharge;
                endingBalance = startingBalance + interestCharge - payment;
                if (endingBalance < 1 &&
                    endingBalance > 0) {
                    endingBalance = 0.00;
                }
                TableData.Add(new PaymentSummary {
                    Month = month,
                    PaymentAmount = MonthlyPaymentRounded,
                    PrinciplePaymentAmount = Math.Round(payment - interestCharge, 2),
                    InterestPaymentAmount = Math.Round(interestCharge, 2),
                    TotalInterestPaid = Math.Round(totalInterestPaid, 2),
                    RemainingBalance = Math.Round(endingBalance, 2)
                });
                startingBalance = endingBalance;
            }

            IList<string> chartLabels = new List<string>();
            DateTime time = DateTime.Now;
            for (int i = 0; i < Months; i++) {
                chartLabels.Add(time.AddMonths(i).ToString("MMM"));
            }
            ChartData = new LoanChart {
                labels = chartLabels.ToArray(),
                lineData = TableData.Select(t => t.PrinciplePaymentAmount).ToArray(),
                barData = TableData.Select(t => t.InterestPaymentAmount).ToArray()

            };
        }
        public double MonthlyPaymentRounded { get; set; }
        public IList<PaymentSummary> TableData { get; set; }
        public LoanChart ChartData { get; set; }
    }
}