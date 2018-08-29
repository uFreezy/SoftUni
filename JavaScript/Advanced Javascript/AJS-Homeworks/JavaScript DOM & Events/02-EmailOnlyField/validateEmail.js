/**
 * Created by ufree on 2/13/2016.
 */

var submitEmail = document.getElementById("submit");
submitEmail.addEventListener("click", validateEmail, false);

function validateEmail() {
    var emailField = document.getElementById('email').value;

    if( /(.+)@(.+){2,}\.(.+){2,}/.test(emailField)) {
        document.getElementById('output').style.backgroundColor = 'green';
        document.getElementById('output').innerText = emailField;
    }
    else {
        document.getElementById('output').style.backgroundColor = 'red';
        document.getElementById('output').innerText = emailField;
    }
}