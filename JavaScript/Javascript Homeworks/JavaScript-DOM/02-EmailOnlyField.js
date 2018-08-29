/**
 * Created by Freezyy on 3/30/2015.
 */
function validateEmail() {
    var str = document.getElementById('inputfield').value;
    if( /(.+)@(.+){2,}\.(.+){2,}/.test(str)) {
        document.getElementById('output').style.backgroundColor = 'green';
        document.getElementById('output').innerHTML = str;
    }
    else {
        document.getElementById('output').style.backgroundColor = 'red';
        document.getElementById('output').innerHTML = str;
    }
}