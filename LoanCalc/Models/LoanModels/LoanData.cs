namespace LoanCalc.Models.LoanModels {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LoanData {
        public LoanData(LoanParams loanParams) {
            Params = loanParams;
            TableData = new List<PaymentSummary>();

            MonthlyPaymentRounded = 
                (Params.Amount * (Params.Rate / 12) * (Math.Pow(1 + Params.Rate / 12, Params.Months))) / 
                (Math.Pow(1 + (Params.Rate / 12), Params.Months) - 1);

            double startingBalance = Params.Amount;
            double endingBalance = Params.Amount;
            double totalInterestPaid = 0.00;

            for (int month = 1; month <= Params.Months; month++) {
                double interestCharge = Params.Rate / 12 * startingBalance;
                totalInterestPaid += interestCharge;
                endingBalance = startingBalance + interestCharge - MonthlyPaymentRounded;
                if (endingBalance < 1 &&
                    endingBalance > 0) {
                    endingBalance = 0.00;
                }
                TableData.Add(new PaymentSummary {
                    Month = month,
                    PaymentAmount = MonthlyPaymentRounded,
                    PrinciplePaymentAmount = Math.Round(MonthlyPaymentRounded - interestCharge, 2),
                    InterestPaymentAmount = Math.Round(interestCharge, 2),
                    TotalInterestPaid = Math.Round(totalInterestPaid, 2),
                    RemainingBalance = Math.Round(endingBalance, 2)
                });
                startingBalance = endingBalance;
            }

            IList<string> chartLabels = new List<string>();
            DateTime time = DateTime.Now;
            for (int i = 0; i < Params.Months; i++) {
                chartLabels.Add(time.AddMonths(i).ToString("MMM"));
            }
            ChartData = new LoanChart {
                labels = chartLabels.ToArray(),
                lineData = TableData.Select(t => t.PrinciplePaymentAmount).ToArray(),
                barData = TableData.Select(t => t.InterestPaymentAmount).ToArray()

            };
        }
        public LoanParams Params { get; set; }
        public double MonthlyPaymentRounded { get; set; }
        public IList<PaymentSummary> TableData { get; set; }
        public LoanChart ChartData { get; set; }
    }
}