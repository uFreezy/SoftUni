/**
 * Created by Freezyy on 4/3/2015.
 */
function solve (arr) {
    for(var i in arr) {
        var splitValues = arr[i].split(/\D/);
        var output = '';
        //var values = [];

        for(var k  = 0;k < splitValues.length; k++) {
            if(splitValues[k] != '') {
                var hex  = parseInt(splitValues[k]).toString(16).toUpperCase();
                while(hex.length < 4) {
                    hex = '0' + hex;
                }
                if(k == 0) {
                    output += '0x' + hex;
                }
                else {
                    output += '-' + '0x' + hex;

                }
            }
        }
        console.log(output);
    }
}

var arr = [
    '5tffwj(//*7837xz',
    '// c2---34rlxXP%$”.'
];
solve(arr);