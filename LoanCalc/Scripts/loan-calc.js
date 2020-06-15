$(() => {
    request('#calculate', true);
})

let activeChart = null;

function request(querySelector, isFirstRequest) {
    $(querySelector).click((e) => {
        e.preventDefault();
        let data = new P();
        console.log(data);
        let pass = validate(data);
        if (!pass) return;
        if (isFirstRequest) {
            $('#deadCenter').fadeOut('slow', 'swing', $('#deadCenter').remove());
        } else {
            $('#table').empty();
        }
        $.ajax({
            async: false,
            url: "/Loan/Table?amount=" + data.Principal + "&months=" + data.TermLengthMonths + "&rate=" + data.InterestRate,
            type: 'GET',
            success: (table) => {
                $('#amount').val(data.Principal);
                $('#months').val(data.TermLengthMonths);
                $('#rate').val(data.InterestRate);
                $('#table').append(table);
                if (isFirstRequest) {
                    $('#result').fadeIn('slow', 'swing');
                }
                request('#newCalc', false);
                getChart(data.Principal, data.TermLengthMonths, data.InterestRate);
            }
        })
    });

    function getChart(amount, months, rate) {
        let qString = "/loan/chart?amount=" + amount + "&months=" + months + "&rate=" + rate;
        fetch(qString)
        .then((response) => {
            return response.json();
        })
        .then((chartData) => {
            if (activeChart != null) {
                activeChart.destroy();
            }
            activeChart = new Chart($('#loanChart'), {
            type: 'bar',
            data: {
                datasets: [
                    {
                        label: 'Interest Payment',
                        data: chartData.barData,
                        order: 1
                    },
                    {
                        label: 'Principle Payment',
                        data: chartData.lineData,
                        type: 'line',
                        order: 2
                    }
                ],
                labels: chartData.labels
                }
            })
        })
    }

    function P() {
        this.Principal = Number($('#amount').val());
        this.TermLengthMonths = Number($('#months').val());
        this.InterestRate = Number($('#rate').val());
    }

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
}