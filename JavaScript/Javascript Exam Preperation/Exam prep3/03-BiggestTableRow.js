/**
 * Created by Freezyy on 3/28/2015.
 */
function solve(arr) {
    function getValues(str) {
        var values = [];

        for(var k = 0; k < 3; k++) {
            values.push(str.slice(str.indexOf('<td>')+4, str.indexOf('</td>')));
            str  = str.slice(str.indexOf('</td>') +4);
        }
        return values;
    }
    arr.splice(0,2);
    arr.splice(arr.length-1,1);
    var maxSum = -9999999999;
    var maxSumValues = [];

    for(var i = 0; i < arr.length; i++) {
        var curValues = [];
        var curSum = 0;
        arr[i] = arr[i].slice(arr[i].indexOf('</td>') + 5);
        curValues = getValues(arr[i]);
        for(var k = 0; k < curValues.length; k++) {
            if(curValues[k] != '-') {
                curSum += parseFloat(curValues[k]);
            }
        }
        if(maxSum < curSum) {
            maxSum = curSum;
            curSum = 0;
            maxSumValues = curValues;
        }

    }
    for(i = 0; i < 3; i++) {
        if(maxSumValues[i] != '-') {
            maxSumValues.push(maxSumValues[i]);
        }
    }
    maxSumValues.splice(0,3);
    //console.log(maxSumValues);
    var output = '';
    output += maxSum + ' = ';
    for(i = 0; i < maxSumValues.length; i++) {
        if(i == maxSumValues.length -1) {
            output += maxSumValues[i];
            break;
        }
        output += maxSumValues[i] + ' + ';
    }
    if(maxSumValues.length == 0) {
        console.log('no data');
    }
    else {
        console.log(output);
    }
}

var arr = [
    '<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<tr><td>Sofia</td><td>0</td><td>-</td><td>0.0</td></tr>',
    '<tr><td>Yambol</td><td>-</td><td>0</td><td>-</td></tr>',
    '<tr><td>Sliven</td><td>-</td><td>0</td><td>-</td></tr>',
    '<tr><td>Kaspichan</td><td>0</td><td>-</td><td>-</td></tr>',
    '</table>'
];
solve(arr);