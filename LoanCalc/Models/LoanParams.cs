namespace LoanCalc.Models {
    public class LoanParams {
        public LoanParams() { }
        public double Principal { get; set; }
        public int TermLengthMonths { get; set; }
        public double InterestRate { get; set; }

    }
}