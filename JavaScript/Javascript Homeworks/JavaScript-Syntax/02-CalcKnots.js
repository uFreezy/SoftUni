/**
 * Created by Freezyy on 3/14/2015.
 */

var km = 20;

for(var i = 0; i < 3; i++) {
    if(i === 1){
        km = 112;
    }
    else if(i === 2) {
        km = 400;
    }
    console.log((km / 1.852).toFixed(2));
}