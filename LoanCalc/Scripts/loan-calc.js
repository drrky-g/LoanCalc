$(() => {
    request('#calculate', true);
})

function request(querySelector, isFirstRequest) {
    $(querySelector).click((e) => {
        e.preventDefault();
        let data = new P();
        let pass = validate(data);
        if (!pass) return;
        if (isFirstRequest) {
            $('#deadCenter').fadeOut('slow', 'swing', $('#deadCenter').remove());
        } else {
            $('#tableArea').empty();
        }
        $.ajax({
            async: false,
            url: "/Loan/Calculate",
            type: 'GET',
            data: data,
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                $('#tableArea').append(data);
                if (isFirstRequest) {
                    $('#tableArea').fadeIn('slow', 'swing');
                }
                request('#newCalc', false);
            }
        })
    });
}

//parameter construction
function P() {
    this.Principal = Number($('#loanAmount').val());
    this.TermLengthMonths = Number($('#monthCount').val());
    this.InterestRate = Number($('#interest').val());
}

//validation
function validate(params) {
    let errs = [];
    let alertText = "Validation Error(s):"
    if (params.Principal <= 0 || typeof (params.Principal) != "number") {
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