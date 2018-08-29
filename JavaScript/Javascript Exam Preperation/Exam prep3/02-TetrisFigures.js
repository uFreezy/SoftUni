/**
 * Created by Freezyy on 3/28/2015.
 */

function solve(arr) {
    function figConst(i,l,j,o,z,s,t) {
        this.I = i;
        this.L = l;
        this.J = j;
        this.O = o;
        this.Z = z;
        this.S = s;
        this.T = t;
    }
    var matrix = [];
    for(var i = 0; i < arr.length; i++) {
        var line = [];
        for(var k = 0; k < arr[i].length; k++) {
            line.push(arr[i][k]);
        }
        matrix.push(line);
        line=[];
    }
    function IFigure(row, col){
        var symbol = matrix[row][col];
        if(symbol == "-") return false;

        if(!matrix[row+1] || matrix[row+1][col] == "-") return false;
        if(!matrix[row+2] || matrix[row+2][col] == "-") return false;
        if(!matrix[row+3] || matrix[row+3][col] == "-") return false;

        return true;
    }
    function LFigure(row, col) {
        var symbol = matrix[row][col];
        if(symbol == '-') return false;

        if(!matrix[row+1] || matrix[row+1][col] == "-") return false;
        if(!matrix[row+2] || matrix[row+2][col] == "-") return false;
        if(!matrix[row+2][col+1] || matrix[row+2][col+1] == "-") return false;
        return true;
    }
    function JFigure(row, col) {
        var symbol = matrix[row][col];
        if(symbol == '-') return false;

        if(!matrix[row+1] || matrix[row+1][col] == "-") return false;
        if(!matrix[row+2] || matrix[row+2][col] == "-") return false;
        if(!matrix[row+2][col-1] || matrix[row+2][col-1] == "-") return false;
        return true;
    }
    function OFigure(row, col) {
        var symbol = matrix[row][col];
        if(symbol == '-') return false;

        if(!matrix[row+1] || matrix[row][col+1] == "-") return false;
        if(!matrix[row+1] || matrix[row+1][col] == "-") return false;
        if(!matrix[row+1][col+1] || matrix[row+1][col+1] == "-") return false;
        return true;
    }
    function ZFigure(row, col) {
        var symbol = matrix[row][col];
        if(symbol == '-') return false;

        if(!matrix[row+1] || matrix[row][col+1] == "-") return false;
        if(!matrix[row+1] || matrix[row+1][col+1] == "-") return false;
        if(!matrix[row+1][col+2] || matrix[row+1][col+2] == "-") return false;
        return true;
    }
    function SFigure(row, col) {
        var symbol = matrix[row][col];
        if(symbol == '-') return false;

        if(!matrix[row+1] || matrix[row][col+1] == "-") return false;
        if(!matrix[row+1][col+1] || matrix[row+1][col] == "-") return false;
        if(!matrix[row+1][col-1] || matrix[row+1][col-1] == "-") return false;
        return true;
    }
    function TFigure(row, col) {
        var symbol = matrix[row][col];
        if(symbol == '-') return false;

        if(!matrix[row+1] || matrix[row][col+1] == "-") return false;
        if(!matrix[row+1][col+2] || matrix[row][col+2] == "-") return false;
        if(!matrix[row+1] || matrix[row+1][col+1] == "-") return false;
        return true;
    }

    var count = [0,0,0,0,0,0,0];
    for(i=0;i<matrix.length-1;i++){
        for(k=0;k<matrix[i].length;k++){
            if(IFigure(i,k)) count[0]++;
            if(LFigure(i,k)) count[1]++;
            if(JFigure(i,k)) count[2]++;
            if(OFigure(i,k)) count[3]++;
            if(ZFigure(i,k)) count[4]++;
            if(SFigure(i,k)) count[5]++;
            if(TFigure(i,k)) count[6]++;
        }
    }
    console.log(JSON.stringify(new figConst(count[0],count[1],count[2],count[3],count[4],count[5],count[6])));
}

var arr = [
    '-oo',
    'ooo',
    'ooo'

];
solve(arr);
