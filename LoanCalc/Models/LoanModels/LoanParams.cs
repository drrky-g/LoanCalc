using System.Collections.Generic;

namespace LoanCalc.Models.LoanModels {
    public class LoanParams {
        public LoanParams() { }
        public double Amount { get; set; }
        public int Months { get; set; }
        public double Rate { get; set; }
        public IList<PaymentSummary> GetTableData() {
            return new LoanData(this).TableData;
        }
        public LoanChart GetChartData() {
            return new LoanData(this).ChartData;
        }
    }
}