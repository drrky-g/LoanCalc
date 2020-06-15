using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanCalc.Models.LoanModels {
    public class LoanChart {
        public LoanChart() { }
        public string[] labels { get; set; }
        public double[] lineData { get; set; }
        public double[] barData { get; set; }
    }
}