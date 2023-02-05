
$(() => {
    clientValidation()

    $("#contactForm").submit((event) => {
        event.preventDefault();
        // Your custom form submission logic goes here
    });
})

var avoidUserSpam = (seconds) =>
{
    var button = document.getElementById('submitButton')
    var oldValue = button.value;
    let milliseconds = seconds * 1000

    setTimeout(() => {
        button.setAttribute('disabled', true);
        button.value = `Wait ${seconds} sec`;
        console.log('calling avoidUserSpam');
    }, 0);

    setTimeout(() => {
        button.value = oldValue;
        button.removeAttribute('disabled');
    }, milliseconds);
}

var clientValidation = () => {
    $('#contactForm').validate({
        rules: {
            name: {
                required: true
            },
            'email': {
                required: true,
                email: true
            },
            'subject': {
                required: true
            },
            'message': {
                required: true,
                minlength: 100,
            },
        },
        messages: {
            'name': {
                required: 'please enter your real name'
            },
            'email': {
                required: 'please enter your email address',
                email: 'please enter a valid email address'
            },
            'subject': {
                required: 'please enter a subject for why you are reaching out'
            },
            'message': {
                required: 'please tell me about yourself and what I can do for you ^_^'
            },
        }
    })
}