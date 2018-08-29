/**
 * Created by Freezyy on 4/5/2015.
 */
function solve(arr) {
    var fleas = [];
    var maxJumps = arr[0];
    var fieldLen = arr[1];
    var fleeRes = [];
    var finnishLinePassed = false;
    var winner = '';
    var audience = '';
    var winnerPassed = false;

    for (var i = 2; i < arr.length; i++) {
        var flee = arr[i].split(', ');
        fleas.push(flee);
        fleeRes.push([flee[0], 0]);
    }
    //console.log(maxJumps);
    //console.log(fieldLen);
    //console.log(fleas);
    //console.log(fleeRes);
    for (i = 0; i < fieldLen; i++) {
        audience += '#';
    }

    for (i = 0; i < maxJumps; i++) {
        for (var k = 0; k < fleas.length; k++) {
            fleeRes[k][1] = parseInt(fleeRes[k][1]) + parseInt(fleas[k][1]);
            //console.log(fleeRes[k][1]);
            //console.log(fieldLen-1);
            if(fleas[k][1] > 10 && fieldLen > fleas[k][1]) {
                fleas[k][1] = 10;
            }
            if (fleeRes[k][1] == fieldLen - 1 || fleeRes[k][1] >= fieldLen) {
                //console.log(fleeRes[k][1]);
                if(fleeRes[k][1] >= fieldLen) {
                    fleeRes[k][1] = fieldLen-1;
                }
                console.log(audience);
                console.log(audience);
                for (var y = 0; y < fleeRes.length; y++) {
                    var line = '';
                    for (var x = 0; x < fieldLen; x++) {
                        if (x == fleeRes[y][1]) {
                            line += fleeRes[y][0][0].toUpperCase();
                        }
                        else {
                            line += '.'
                        }
                    }
                    console.log(line);
                }
                console.log(audience);
                console.log(audience);
                console.log('Winner: ' + fleeRes[k][0]);
                finnishLinePassed = true;
                break;
            }
            else if (fleeRes[k][1] > fieldLen) {
                winnerPassed = true;
                winner = fleeRes[k][0];
            }
        }
        if (finnishLinePassed) {
            break;
        }
    }
    if (!finnishLinePassed) {
        if (winnerPassed) {
            console.log(audience);
            console.log(audience);
            for (y = 0; y < fleeRes.length; y++) {
                line = '';
                for (x = 0; x < fieldLen; x++) {
                    if (x == fleeRes[y][1]) {
                        line += fleeRes[y][0][0].toUpperCase();
                    }
                    else {
                        line += '.'
                    }
                }
                console.log(line);
            }
            console.log(audience);
            console.log(audience);
            console.log('Winner: ' + winner);
        }
        else {
            var biggest = '';
            for (i = 0; i < fleeRes.length; i++) {
                if (i + 1 == fleeRes.length) {
                    break;
                }
                if (fleeRes[i][1] > fleeRes[i + 1][1]) {
                    biggest = fleeRes[i][0]
                }
                else if (fleeRes[i][1] < fleeRes[i + 1][1]) {
                    biggest = fleeRes[i + 1][0]
                }
                else {
                    biggest = fleeRes[i + 1][0]
                }
            }
            console.log(audience);
            console.log(audience);
            for (y = 0; y < fleeRes.length; y++) {
                line = '';
                for (x = 0; x < fieldLen; x++) {
                    if (x == fleeRes[y][1]) {
                        line += fleeRes[y][0][0].toUpperCase();
                    }
                    else {
                        line += '.'
                    }
                }
                console.log(line);
            }
            console.log(audience);
            console.log(audience);
            console.log('Winner: ' + biggest);
        }
        // The flee who is closest to the finnish wins
    }
    //console.log(typeof  fleeRes[0][1]);
}
var arr= ['10','100','angel, 11','Boris, 10','Georgi, 3','Dimitar, 7'];
solve(arr);