/**
 * Created by Freezyy on 3/22/2015.
 */
function solve(arr) {
    var degree = arr[0].replace( /^\D+/g, '');
    degree = degree.slice(0,degree.length-1);

    degree = parseInt(degree);
    var whiteSpace = " ";

    while(degree>=360){
        degree -= 360;
    }
    //console.log(degree);

    var maxLen = -1;
    var matrix = [];

    for(var i=1;i<arr.length;i++){
        if(arr[i].length>maxLen)
            maxLen = arr[i].length;
    }

    //console.log(maxLen);
    function show(){
        var line = "";
        var output = "";
        for(i = 0; i < matrix.length; i++) {
            for(k = 0; k < matrix[i].length; k++) {
                line += matrix[i][k];
            }
            output += line + "\n";
            line = "";
        }
        return output;
    }

    if(degree == 90 || degree == 270){
        var matrixLine = [];
        for(i=0;i<maxLen;i++){
            for( j=1;j<arr.length;j++){
                matrixLine.push(whiteSpace);
            }
            matrix.push(matrixLine);
            matrixLine = [];
        }
        if(degree == 90) {
            arr = arr.reverse();
            for(i = arr.length-2; i >= 0; i--) {
                for(var k = 0; k < maxLen; k++) {
                    matrix[k][i] = arr[i][k] || whiteSpace;
                }
            }
        }
        else{

            for(i = arr.length-1; i > 0; i--) {
                var t =0;
                for(k = maxLen-1; k  >= 0; k--) {
                    matrix[t++][i-1] = arr[i][k] || whiteSpace;
                }
                t=0;
            }

        }

        //console.log(matrix);

    }
    else{
        if(degree==180) {
            var matrixLine = [];
            for (i = 1; i < arr.length; i++) {
                for (var j = 0; j < maxLen; j++) {
                    matrixLine.push(whiteSpace);
                }
                matrix.push(matrixLine);
                matrixLine = [];
            }
            arr.splice(0, 1);
            arr.reverse();
            console.log();
            for (i = arr.length - 1; i >= 0; i--) {
                for (j = 0; j < arr[i].length; j++) {
                    matrix[i][j] = arr[i][j];
                }
                matrix[i].reverse();
            }

            //console.log(matrix);
        }
        if(degree==0){
            //console.log(matrix);
            arr.splice(0,1);
            matrixLine = [];
            for (i = 0; i < arr.length; i++) {
                for (j = 0; j < maxLen; j++) {
                    matrixLine.push(whiteSpace);
                }
                matrix.push(matrixLine);
                matrixLine = [];
            }
            //console.log(matrix);
            for(i=0;i<arr.length;i++){
                for(j=0;j<arr[i].length;j++){
                    matrix[i][j] = arr[i][j];

                    //console.log(arr[i][j]);
                }
            }
        }
    }
    return show();
    //console.log(show());
}

var arr = ["Rotate(270)","hello", "softuni", "exam"];
solve(arr);