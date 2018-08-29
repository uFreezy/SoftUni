/**
 * Created by Freezyy on 3/14/2015.
 */

var arr = [2,4],
    arr2 = [5,8],
    arr3 = [12,3];

calcCylinderVol(arr);
calcCylinderVol(arr2);
calcCylinderVol(arr3);

function calcCylinderVol(arr) {
    console.log((Math.PI * (arr[0]*arr[0]) * arr[1]).toFixed(3));
}