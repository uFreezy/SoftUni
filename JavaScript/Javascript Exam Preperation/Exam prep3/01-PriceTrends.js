/**
 * Created by Freezyy on 3/27/2015.
 */
function solve(arr) {
    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    console.log('<tr><td>' + parseFloat(arr[0]).toFixed(2) + '</td><td><img src="fixed.png"/></td></td>');
    for(var i = 0; i < arr.length-1; i++) {
        if(parseFloat(parseFloat(arr[i]).toFixed(2)) < parseFloat(parseFloat(arr[i+1]).toFixed(2))) {
            console.log('<tr><td>' + parseFloat(arr[i+1]).toFixed(2) + '</td><td><img src="up.png"/></td></td>');
        }
        else if(parseFloat(parseFloat(arr[i]).toFixed(2)) > parseFloat(parseFloat(arr[i+1]).toFixed(2))) {
            console.log('<tr><td>' + parseFloat(arr[i+1]).toFixed(2) + '</td><td><img src="down.png"/></td></td>');
        }
        else {
            console.log('<tr><td>' + parseFloat(arr[i+1]).toFixed(2) + '</td><td><img src="fixed.png"/></td></td>');
        }
    }
    console.log('</table>');
}

var arr = [
    1,
    1.0,
    1.00,
    1.001,
    1.000001,
    2,
    2.0,
    2.00,
    2.10,
    2.0,
    2.10,
    2.0,
    1.99,
    1.999,
    1.99001,
    1.99002,
    1.99003,
    4.00,
    5.00,
    342.33,
    23.44,
    5.22,
    3.44,
    7.22,
    2

];
solve(arr);