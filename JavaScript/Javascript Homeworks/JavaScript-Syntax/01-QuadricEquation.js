/**
 * Created by Freezyy on 3/14/2015.
 */

var a = 2,
    b = 5,
    c = -3;

for(var i = 0; i < 3; i++) {
    if(i === 1) {
        a = 2;
        b = -4;
        c = 2;
    }
    else if (i === 2) {
        a = 4;
        b = 2;
        c = 1;
    }
    if((b*b) - (4*a*c) > 0) {
        console.log("x1 = " + (-b - Math.sqrt( ((b*b) - (4*a*c)) ) ) / (2*a));
        console.log("x2 = " + (-b + Math.sqrt( ((b*b) - (4*a*c)) ) ) / (2*a) + "\n");
    }
    else if((b*b) - (4*a*c) === 0) {
        console.log("x = " + (-(b/(2*a))) + "\n");
    }
    else {
        console.log("No real roots. \n");
    }
}
