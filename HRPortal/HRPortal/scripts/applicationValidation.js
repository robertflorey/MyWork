$(document).ready(function () {
    $('#applicationForm').validate({
        rules: {
            Name: {
                required: true
            },
            Address: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            Reason: {
                required: true
            }
        },
        messages: {
            Name: "Please enter your Name!",
            Address: "Please tell us your address",
            Email: {
                required: "Please enter an Email",
                email: "Please enter a Valid Email"
            },
            Reasoon: "Please tell us why you would like to work here."
        }
    });
});