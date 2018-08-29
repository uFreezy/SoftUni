/**
 * Created by Freezyy on 3/22/2015.
 */
function RakiyaNumbers(arr) {
    var ifRakiya = false;
    console.log('<ul>');
    for(var i = parseInt(arr[0]); i <= parseInt(arr[1]); i++) {
        for(var k = 0; k < i.toString().length;k++) {
            if(k+1 < i.toString().length) {
                var numbToS = i.toString();
                var check = numbToS.slice(k,k+2);
                numbToS = numbToS.replace(check, "--");
                if(numbToS.indexOf(check)> -1) {
                    ifRakiya = true;
                    console.log("<li><span class='rakiya'>"+ i + '</span><a href="view.php?id=' + i + '>View</a></li>');
                    break;
                }
            }
        }
        if(!ifRakiya) {
            console.log("<li><span class='num'>" + i + "</span></li>");
        }
        ifRakiya = false;
    }
    console.log('</ul>');
}


var input = ['11210','11215'];
RakiyaNumbers(input);