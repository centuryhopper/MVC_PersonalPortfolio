$(() => {
    clientValidation()

    // definitely dont want to preventdefault for a form submission! I commented this out after finding out this is why the form information wasn't submitting!
    // $("#contactForm").submit((event) => {
    //     event.preventDefault()
    //     // Your custom form submission logic goes here
    // })
})


const avoidUserSpam = (seconds) =>
{
    if (Number.isNaN(seconds) || seconds <= 0 || seconds === undefined)
    {
        console.error("you need to pass in a positive integer when calling avoidUserSpam()")
        return
    }
    //#region disable the button
    var button = document.getElementById('submitButton')
    var oldValue = button.value
    button.setAttribute('disabled', true)
    //#endregion

    var num = seconds

    // Update the count down every 1 second
    const interval = setInterval(() =>
    {
        button.value = 'Wait ' + num-- + "s "


        // If the count down is finished, write some text
        if (num <= 0)
        {
            clearInterval(interval)
            button.value = oldValue
            button.removeAttribute('disabled')
        }
    }, 1000)
}

const clientValidation = () => {
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

