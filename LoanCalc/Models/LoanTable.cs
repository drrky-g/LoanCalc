using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanCalc.Models {
    public class LoanTable {
        public LoanTable(LoanParams @params) {
            Params = @params;
            TableData = new List<PaymentSummary>();
        }
        public LoanParams Params { get; set; }
        public IList<PaymentSummary> TableData { get; set; }
    }
}