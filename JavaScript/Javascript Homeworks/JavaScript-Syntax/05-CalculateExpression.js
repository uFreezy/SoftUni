/**
 * Created by Freezyy on 3/14/2015.
 */

var stringExp;

function getValue() {
    stringExp = document.getElementById("input").value;
    calc(stringExp);
}
function calc(stringExp) {
    document.getElementById('result').innerHTML = eval(stringExp).toString();
}