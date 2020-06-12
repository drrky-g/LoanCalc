$(() => {
    //initial calculation request
    $('#calculate').click((e) => {
        e.preventDefault();
        var data = new P();
        var pass = validate(data);
        if (!pass) return;
        $('#deadCenter').fadeOut('slow', 'swing', $('#deadCenter').remove());
        $.ajax({
            async: false,
            url: "/Loan/Calculate",
            type: 'GET',
            data: data,
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                $('#tableArea').append(data);
                $('#tableArea').fadeIn('slow', 'swing');
                followupRequest();
            }
        })
    })
    //bind followup requst to incoming form
    function followupRequest() {
        $('#newCalc').click((e) => {
            e.preventDefault();
            var data = new P();
            var pass = validate(data);
            if (!pass) return;
            $('#tableArea').empty();
            $.ajax({
                async: false,
                url: "/Loan/Calculate",
                type: 'GET',
                data: data,
                contentType: "application/json; charset=utf-8",
                success: (data) => {
                    replaceTable(data);
                    followupRequest();
                }
            })
        });
    }
    //replace an existing table with the updated version
    function replaceTable(html) {
        $('#tableArea').append(html);
    }
    //parameter construction
    function P() {
        this.Principal = Number($('#loanAmount').val());
        this.TermLengthMonths = Number($('#monthCount').val());
        this.InterestRate = Number($('#interest').val());
    }

    //validation
    function validate(params) {
        var errs = [];
        var alertText = "Validation Error(s):"
        if (params.Principal <= 0 || typeof(params.Principal) != "number") {
            errs.push(" You must have a loan amount to calculate the loan.")
        }
        if (params.InterestRate <= 0 || typeof (params.InterestRate) != "number") {
            errs.push(" You must have an interest rate to calculate the loan.");
        }
        if (params.TermLengthMonths <= 0 || typeof (params.TermLengthMonths) != "number") {
            errs.push(" You must have a term length to calculate the loan.")
        }
        if (errs.length > 0) {
            errs.forEach((x) => { alertText += x });
            alert(alertText);
            return false;
        }
        return true;
    }
})