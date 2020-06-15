namespace LoanCalc.Models.LoanModels {
    public class PaymentSummary {
        public PaymentSummary() { }
        public int Month { get; set; }
        public double PaymentAmount { get; set; }
        public double PrinciplePaymentAmount { get; set; }
        public double InterestPaymentAmount { get; set; }
        public double TotalInterestPaid { get; set; }
        public double RemainingBalance { get; set; }
    }
}