$(() => {
    clientValidation()

    $("#contactForm").submit((event) => {
        event.preventDefault()
        // Your custom form submission logic goes here
    })
})


const avoidUserSpam = (seconds) =>
{
    //#region disable the button
    var button = document.getElementById('submitButton')
    var oldValue = button.value
    button.setAttribute('disabled', true)
    //#endregion

    //#region show the wait time
    // Set tomorrow as the we're counting down to
    var today = new Date()
    var tomorrow = new Date(today)
    tomorrow.setDate(tomorrow.getDate() + 1)

    // Update the count down every 1 second
    const interval = setInterval(() =>
    {
        // Get todays date and time
        var now = new Date().getTime()

        // Find the distance between now and the count down date
        var distance = tomorrow - now

        // Time calculations for days, hours, minutes and seconds
        var seconds = Math.floor((distance % (1000 * 60)) / 1000 / 2)

        // Display the result in the element with id="timer"
        button.value = 'Wait ' + seconds + "s "

        // console.log(button.value)

        // If the count down is finished, write some text
        if (seconds <= 0)
        {
            clearInterval(interval)
            button.value = oldValue
            button.removeAttribute('disabled')
        }
    }, 1000)
    //#endregion
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