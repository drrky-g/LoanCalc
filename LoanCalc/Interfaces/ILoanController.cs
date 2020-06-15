namespace LoanCalc.Interfaces {
    using LoanCalc.Models.LoanModels;
    using System.Web.Mvc;
    interface ILoanController {
        //'Presenter' View
        ViewResult App();
        // Polymorphic Form Component
        PartialViewResult Form(bool isStart);
        // Table Component
        PartialViewResult Table(double amount, int months, double rate);
        // Chart Data Json Endpoint
        JsonResult Chart(double amount, int months, double rate);
    }
}