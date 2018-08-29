/**
 * Created by Freezyy on 4/5/2015.
 */
function solve(arr) {


    var directions =  arr[0].split(', ');
    var matrix = [];
    var bunnyCurPos = [0,0];
    var eatenVals = {
        "&" : 0,
        "*" : 0,
        "#" : 0,
        "!" : 0,
        "wall hits" : 0
    };
    var bunnyStr = '';

    arr.shift();
    for(var indx in arr) {
        var line = [];
        line = arr[indx].split(', ');
        matrix.push(line);
    }
    var mirrorMatrix = matrix;
    for(var i = 0; i < directions.length; i++) {
        if(directions[i] == 'left') {
            if(bunnyCurPos[1]-1 >= 0) {
                bunnyCurPos[1]--;
            }
            else {
                eatenVals['wall hits']++;
            }

        }
        else if(directions[i] == 'right') {
            if(bunnyCurPos[1]+1 < matrix[bunnyCurPos[0]].length) {
                bunnyCurPos[1]++;
            }
            else {
                eatenVals['wall hits']++;
            }

        }
        else if(directions[i] == 'up') {
            if(bunnyCurPos[0]-1 >= 0  && matrix[bunnyCurPos[0]-1][bunnyCurPos[1]]) {
                bunnyCurPos[0]--;
            }
            else {
                eatenVals['wall hits']++;
            }

        }
        else if(directions[i] == 'down') {
            if(bunnyCurPos[0]+1 <= matrix.length-1 && matrix[bunnyCurPos[0]+1][bunnyCurPos[1]]) {
                bunnyCurPos[0]++;
            }
            else {
                eatenVals['wall hits']++;
            }
        }
        var y = bunnyCurPos[0];
        var x = bunnyCurPos[1];
        if(matrix.length > 1) {
            if(matrix[y][x].indexOf('{!}') > -1){
                eatenVals["!"]+= (matrix[y][x].match(/{!}/g) || []).length;
                matrix[y][x] = matrix[y][x].replace('{!}', '@');
                mirrorMatrix[y][x] = mirrorMatrix[y][x].replace('{!}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[y][x]) <= -1){
                    bunnyStr += mirrorMatrix[y][x].replace('{!}', '@') + '|';
                }

            }
            else if(matrix[y][x].indexOf('{*}') > -1) {
                eatenVals["*"]+= (matrix[y][x].match(/{*}/g) || []).length;
                matrix[y][x] = matrix[y][x].replace('{*}', '@');
                mirrorMatrix[y][x] = mirrorMatrix[y][x].replace('{*}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[y][x]) <= -1){
                    bunnyStr += mirrorMatrix[y][x].replace('{*}', '@') + '|';
                }
            }
            else if(matrix[y][x].indexOf('{&}') > -1) {
                eatenVals["&"]+= (matrix[y][x].match(/{&}/g) || []).length;
                matrix[y][x] = matrix[y][x].replace('{&}', '@');
                mirrorMatrix[y][x] = mirrorMatrix[y][x].replace('{&}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[y][x]) <= -1){
                    bunnyStr += mirrorMatrix[y][x].replace('{&}', '@') + '|';
                }
            }
            else if(matrix[y][x].indexOf('{#}') > -1) {
                eatenVals["#"]+= (matrix[y][x].match(/{#}/g) || []).length;
                matrix[y][x] = matrix[y][x].replace('{#}', '@');
                mirrorMatrix[y][x] = mirrorMatrix[y][x].replace('{#}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[y][x]) <= -1){
                    bunnyStr += mirrorMatrix[y][x].replace('{#}', '@') + '|';
                }
            }
        }
        else {
            if(matrix[0].indexOf('{!}') > -1){
                eatenVals["!"]+= (matrix[0].match(/{!}/g) || []).length;
                matrix[0] = matrix[0].replace('{!}', '@');
                mirrorMatrix[0] = mirrorMatrix[0].replace('{!}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[0]) <= -1){
                    bunnyStr += mirrorMatrix[0].replace('{!}', '@') + '|';
                }
                //matrix[0] = matrix[0].replace('{!}', '@');


            }
            else if(matrix[0].indexOf('{*}') > -1) {
                eatenVals["*"]+= (matrix[0].match(/{*}/g) || []).length;
                matrix[0] = matrix[0].replace('{*}', '@');
                mirrorMatrix[0] = mirrorMatrix[0].replace('{*}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[0]) <= -1){
                    mirrorMatrix[0] = mirrorMatrix[0].replace('{*}', '@');
                    bunnyStr += mirrorMatrix[0].replace('{*}', '@') + '|';
                }
            }
            else if(matrix[0].indexOf('{&}') > -1) {
                eatenVals["&"]+= (matrix[0].match(/{&}/g) || []).length;
                matrix[0] = matrix[0].replace('{&}', '@');
                mirrorMatrix[0] = mirrorMatrix[0].replace('{&}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[0]) <= -1){
                    mirrorMatrix[0] = mirrorMatrix[0].replace('{&}', '@');
                    bunnyStr += mirrorMatrix[0].replace('{&}', '@') + '|';
                }

            }
            else if(matrix[0].indexOf('{#}') > -1) {
                eatenVals["#"]+= (matrix[0].match(/{#}/g) || []).length;
                matrix[0] = matrix[0].replace('{#}', '@');
                mirrorMatrix[0] = mirrorMatrix[0].replace('{#}', '@');
                if(bunnyStr.split("|").indexOf(mirrorMatrix[0]) <= -1){
                    mirrorMatrix[0] = mirrorMatrix[0].replace('{#}', '@');
                    bunnyStr += mirrorMatrix[0].replace('{#}', '@') + '|';
                }
            }
        }
    }

    bunnyStr = bunnyStr.slice(0,bunnyStr.length-1);
    if(bunnyStr == '') {
        bunnyStr = 'no';
    }
    console.log(JSON.stringify(eatenVals));
    console.log(bunnyStr);
}

var arr = ['right, down, down, right, up, up, right, right, right, left, left, right, right',
          'tr{X}yrty                      ,',
          'asdf',
          'as*aj{*}dasd                        , kjldk{!}fdffd, jdflk{#}jdfj',
          'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne'];
solve(arr);