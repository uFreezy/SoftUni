/**
 * Created by Freezyy on 3/11/2015.
 */
function getHex(decimal) {
    return Number(decimal).toString(16).toUpperCase();
}
var decimal = prompt("Give me decimal number:");
alert(getHex(decimal));


