/**
 * Created by Freezyy on 3/31/2015.
 */
function solve(arr) {
    var matrix = [];
    var cordinates = [];

    for(var indx in arr) {
        var line = [];
        for(var i = 0; i < arr[indx].length; i++) {
            line.push(arr[indx][i]);
        }
        matrix.push(line);
    }
    //console.log(matrix);
    function checkX(row, col){
        var curSymbol = matrix[row][col].toLowerCase();

        if(curSymbol == '') return false;
        if(!matrix[row+2])return false;
        if(!matrix[row][col+2]) return false;
        if(!matrix[row+1][col+1]) return false;
        if(!matrix[row+2][col+2]) return false;

        if(matrix[row][col+2].toLowerCase() != curSymbol) return false;
        if(matrix[row+1][col+1].toLowerCase() != curSymbol) return false;
        if(matrix[row+2][col+2].toLowerCase() != curSymbol) return false;
        if(matrix[row+2][col].toLowerCase() != curSymbol) return false;
        return true;

    }
    function removeX(row, col){
        matrix[row][col] = '';
        matrix[row][col+2] = '' ;
        matrix[row+1][col+1] = '';
        matrix[row+2][col+2] = '';
        matrix[row+2][col] = '';
    }
    for(i =0;i< matrix.length;i++){
        for(var j =0;j<matrix[i].length;j++){
            if(checkX(i, j)){
                //removeX(i, j);
                cordinates.push({
                    row: i,
                    col: j
                });
            }
        }
    }
    for(i = 0; i < cordinates.length; i++) {
        removeX(cordinates[i].row,cordinates[i].col);
    }
    var output="";
    for(i=0;i<matrix.length;i++){
        output += matrix[i].join("") + "\n";
    }

    console.log(output.trim());
}

var arr = [
    'puoUdai',
    'miU',
    'ausupirina',
    '8n8i8',
    'm8o8a',
    '8l8o860',
    'M8i8',
    '8e8!8?!'
];
solve(arr);