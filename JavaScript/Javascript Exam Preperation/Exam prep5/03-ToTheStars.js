/**
 * Created by Freezyy on 4/3/2015.
 */
function solve(arr) {
    function checkCollision(x,y,starPos) {
        for(var i = 0; i < starPos.length; i++) {
            if(x >= starPos[i][1]-1 && x <= starPos[i][1]+1 && y >= starPos[i][2]-1 && y <= starPos[i][2]+1) return starPos[i][0].toLowerCase();
        }
        return 'space';
    }
    var starPos = [];
    var shipPos = arr[3].split(' ');

    shipPos[0] = parseFloat(shipPos[0]);
    shipPos[1] = parseFloat(shipPos[1]);

    for(var i = 0; i < 3; i++) {
        var star = arr[i].split(' ');
        star[1] = parseFloat(star[1]);
        star[2] = parseFloat(star[2]);
        starPos.push(star);
        star = [];
    }
    console.log(checkCollision(shipPos[0],shipPos[1],starPos));
    for(i = 0; i < parseInt(arr[4]); i++){
        shipPos[1]++;
        console.log(checkCollision(shipPos[0],shipPos[1],starPos));
    }
}

var arr = [
    'star01 16 16',
    'star02 20 20',
    'star03 14.5 8',
    '15.5 16.1',
    '1'
];
solve(arr);