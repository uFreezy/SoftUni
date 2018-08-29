/**
 * Created by Freezyy on 4/1/2015.
 */
function solve(arr) {
    function calc(int) {
        var line = '<tr><td>' + int + '</td><td>';

        for(var i = 0; i <  Number.MAX_VALUE; i++) {
            for(var k = 0; k < 7; k++) {
                if(int == (i*5+k)) {
                    if(k == 1 || k == 6) {
                        if(int > 40) {
                            line += 'sword</td><td>blade</td></tr>';
                            return line;
                        }
                        else {
                            line += 'dagger</td><td>blade</td></tr>';
                            return line;
                        }
                    }
                    else if(k == 2 || k == 7) {
                        if(int > 40) {
                            line += 'sword</td><td>quite a blade</td></tr>';
                            return line;
                        }
                        else {
                            line += 'dagger</td><td>quite a blade</td></tr>';
                            return line;
                        }
                    }
                    else if(k == 3){
                        if(int > 40) {
                            line += 'sword</td><td>pants-scraper</td></tr>';
                            return line;
                        }
                        else {
                            line += 'dagger</td><td>pants-scraper</td></tr>';
                            return line;
                        }
                    }
                     else if(k == 4){
                        if(int > 40) {
                            line += 'sword</td><td>frog-butcher</td></tr>';
                            return line;
                        }
                        else {
                            line += 'dagger</td><td>frog-butcher</td></tr>';
                            return line;
                        }
                    }
                    else {
                        if(int > 40) {
                            line += 'sword</td><td>*rap-poker</td></tr>';
                            return line;
                        }
                        else {
                            line += 'dagger</td><td>*rap-poker</td></tr>';
                            return line;
                        }
                    }
                    //var output = i + ' * 5 + ' + k;
                    //return output;
                }
            }
        }
    }

    console.log('<table border="1">');
    console.log('<thead>');
    console.log('<tr><th colspan="3">Blades</th></tr>');
    console.log('<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>');
    console.log('</thead>');
    console.log('<tbody>');

    for(var i = 0; i < arr.length; i++) {
        arr[i] = Math.floor(arr[i]);
        if(arr[i] > 10) {
            console.log(calc(arr[i]));
        }

    }
    console.log('</tbody>');
    console.log('</table>');
}

var arr = [
    17.8,
    19.4,
    13,
    55.8,
    126.96541651,
    3

];
solve(arr);