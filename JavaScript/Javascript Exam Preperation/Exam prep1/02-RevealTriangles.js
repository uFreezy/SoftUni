/**
 * Created by Freezyy on 3/19/2015.
 */
function solve(s) {
    Array.prototype.contains = function(num){
        for(t in this){
            if(this[t] == num)return true;
        } return false;
    };
    var output = "",
        line = "",
        holdInd  = {};
    for(var i = 0; i < s.length + 200; i++){
        holdInd[i] = [];
    }
    var lastInd = s.length-1;

    for(i = 0; i < s.length-1; i++) {
        line = s[i][0];

        if (holdInd[i].contains(0)) {
            line = "*";
        }
        for (var k = 1; k < s[i].length; k++) {
            var curS = s[i][k];
            if (curS == s[i + 1][k] && curS == s[i + 1][k - 1] && curS == s[i + 1][k + 1]) {
                line += "*";
                holdInd[i + 1].push(k);
                holdInd[i + 1].push(k - 1);
                holdInd[i + 1].push(k + 1);
            }
            else {
                if (holdInd[i].contains(k)) {
                    line += "*";
                }
                else {
                    line += curS;
                }
            }
        }
        var curS = s[i][s[i].length-1],
            k = s[i].length-1;

        if (holdInd[i].contains(s[i].length - 1)) {
            line += "*";
        }
        else {
            if (curS == s[i + 1][k] && curS == s[i + 1][k - 1] && curS == s[i + 1][k + 1]) {
                line += "*";
                holdInd[i + 1].push(k);
                holdInd[i + 1].push(k - 1);
                holdInd[i + 1].push(k + 1);
            }
            else{
                line += s[i][s[i].length - 1];
            }
        }
        if(line.length > s[i].length){
            line = line.slice(0, line.length-1);
        }
        output += line + "\n";
    }
    line = "";
    for(i = 0; i < s[lastInd].length; i++){
        var curS = s[lastInd][i];
        if(holdInd[lastInd].contains(i)){
            line += "*";
        }
        else{
            line += curS;
        }
    }
    output += line+"\n";
    return output;
}