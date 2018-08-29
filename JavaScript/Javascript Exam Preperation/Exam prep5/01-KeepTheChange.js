/**
 * Created by Freezyy on 4/3/2015.
 */
function solve(arr) {
    if(arr[1] == 'happy') {
        var precent = parseFloat(arr[0]) / 100;
        var tip = precent * 10;

        console.log(tip.toFixed(2));
    }
    else if(arr[1] == 'married') {
         precent = parseFloat(arr[0]) / 100;
         tip = precent * 0.05;

        console.log(tip.toFixed(2));
    }
    else if(arr[1] == 'drunk') {
         precent = parseFloat(arr[0]) / 100;
         tip = precent * 15;
         tip = Math.pow(tip,parseInt(tip.toString()[0]));

        console.log(tip.toFixed(2));
    }
    else {
         precent = parseFloat(arr[0]) / 100;
         tip = precent * 5;

        console.log(tip.toFixed(2));
    }
}

var arr = [
    '1230.83',
    'drunk'
];
solve(arr);