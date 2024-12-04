$(document).ready(function () {

    $("#cookieConsentdiv button").on("click", function () {
        setCookie();
    });
});

function setCookie() {
    $.ajax({
        url: '/ConsentCookies/SetCookie',
        method: 'GET',
        success: function (response) {
            //console.log('Cookie set successfully!');
            // Hide the consent div after setting the cookie
            $("#cookieConsentdiv").hide();
            // Persist the information that the user has accepted the cookie policy
        },
        error: function (xhr, status, error) {
            console.error('Failed to set cookie.');
        }
    });
}