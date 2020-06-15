namespace LoanCalc.Interfaces {
    using LoanCalc.Models;
    using System.Web.Mvc;
    interface ILoanController {
        //Parameter object used throughout controller
        LoanParams loan { get; set; }
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