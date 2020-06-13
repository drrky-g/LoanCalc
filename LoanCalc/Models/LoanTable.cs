namespace LoanCalc.Models {
    using System;
    using System.Collections.Generic;
    public class LoanTable {
        public LoanTable(LoanParams loan) {
            Params = loan;
            TableData = new List<PaymentSummary>();

            double amount = Math.Round(loan.Principal, 2);
            double rate = loan.InterestRate / 100;
            double payment = Math.Round((amount * (rate / 12) * (Math.Pow(1 + rate / 12, loan.TermLengthMonths))) / (Math.Pow(1 + (rate / 12), loan.TermLengthMonths) - 1), 2);

            double startingBalance = amount;
            double endingBalance = amount;
            double totalInterestPaid = 0.00;

            for (int month = 1; month <= loan.TermLengthMonths; month++) {
                double interestCharge = Math.Round(rate / 12 * startingBalance, 2);
                totalInterestPaid += interestCharge;
                endingBalance = Math.Round(startingBalance + interestCharge - payment, 2);
                if (endingBalance < 1 &&
                    endingBalance > 0) {
                    endingBalance = 0.00;
                }
                TableData.Add(new PaymentSummary {
                    Month = month,
                    PaymentAmount = payment,
                    PrinciplePaymentAmount = payment - interestCharge,
                    InterestPaymentAmount = interestCharge,
                    TotalInterestPaid = totalInterestPaid,
                    RemainingBalance = endingBalance
                });
                startingBalance = endingBalance;
            }
        }
        public LoanParams Params { get; set; }
        public IList<PaymentSummary> TableData { get; set; }
    }
}