/**
 * Created by Freezyy on 3/15/2015.
 */

function solve(args){
    var input = args;
    Array.prototype.contains = function(numb) {
        for (i in this) {
            if (this[i] == numb) {
                return true;
            }
        }
        return false;
    };
    function getFib(numb) {
        if(numb == 1) return [1];
        if(numb == 2) return [1, 2];
        if(numb == 3) return [1, 2, 3];
        var array = [1,2,3],
            a = 1,
            b = 2,
            c = 3;
        while(c <= numb) {
            a = b;
            b = c;
            c = a + b;
            array.push(c);
        }
        return array;
    }
    var output = "";
    var fib = getFib(input[1] * 1);
    output += "<table>\n";
    output += "<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n";
    for(var k = input[0] * 1; k <= input[1] * 1; k++) {
        output += "<tr><td>";
        output += k;
        output += "</td><td>";
        output += k*k;
        output += "</td><td>";
        if(fib.contains(k)) {
            output += "yes";
        }
        else {
            output += "no";
        }
        output += "</td></tr>\n";
    }
    return (output + "</table>");
}

