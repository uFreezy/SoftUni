/**
 * Created by Freezyy on 3/26/2015.
 */
function solve (arr) {
    var objHolder = {};
    function team(goalsScored,goalsConceded,matchesPlayedWith) { // main object constructor
        this.goalsScored = goalsScored;
        this.goalsConceded = goalsConceded;
        this.matchesPlayedWith = new Array(matchesPlayedWith);
    }
    function addSecondaryData(objHolder,temp) { // algorithm for adding the secondary scores
        if(typeof  objHolder[temp[i][1]] == 'undefined') {
            objHolder[temp[i][1]] = new team(parseInt(temp[i][3]),parseInt(temp[i][2]),temp[i][0]);
        }
        else {
            objHolder[temp[i][1]].goalsScored += parseInt(temp[i][3]);
            objHolder[temp[i][1]].goalsConceded += parseInt(temp[i][2]);

            if(objHolder[temp[i][1]].matchesPlayedWith.indexOf(temp[i][0]) <= -1) {
                objHolder[temp[i][1]].matchesPlayedWith.push(temp[i][0]);
            }
        }
        return objHolder;
    }

    var temp = [];
    for(var i = 0; i < arr.length; i++) {

        temp.push(arr[i].split(/[^\w\s]/g)); // splits the input for every special char thats not whitespace
        for(var column in temp) {
            for(var row in temp[column]) {
                temp[column][row] = temp[column][row].trim();
            }
        }
        if(typeof objHolder[temp[i][0]] == 'undefined') { // checks if element with  given key is defined or not
            objHolder[temp[i][0]] = new team(parseInt(temp[i][2]),parseInt(temp[i][3]),temp[i][1]); // adds data for the main team
            objHolder = addSecondaryData(objHolder,temp); // adds data for the secondary team
        }
        else {
            objHolder[temp[i][0]].goalsScored += parseInt(temp[i][2]);
            objHolder[temp[i][0]].goalsConceded += parseInt(temp[i][3]);
            if(objHolder[temp[i][0]].matchesPlayedWith.indexOf(temp[i][1]) <= -1) {
                objHolder[temp[i][0]].matchesPlayedWith.push(temp[i][1]);
            }
            objHolder = addSecondaryData(objHolder,temp); // adds data for the second team

        }

    }
    for(var arr in objHolder) {
        objHolder[arr].matchesPlayedWith.sort(); // iterates through the inner array and sorts its values
    }
    var keys = Object.keys(objHolder);
    var swapped;
    do {
        swapped = false;
        for (column = 0; column < keys.length - 1; column++) {
            if (keys[column] > keys[column+1]) {
                var buffer = keys[column];
                keys[column] = keys[column+1];
                keys[column+1] = buffer;
                swapped = true;
            }
        }
    } while (swapped); // sorts array holding object keys
    var output = {};
    for(var m = 0; m < keys.length; m++) {
        output[keys[m]] = objHolder[keys[m]]; // puts the keys and the values in the final output array
    }
    console.log(JSON.stringify(output));
}

var arr = [
    'Levski / CSKA: 0-2',
    'Pavlikeni / Loko Gorna: 4-2',
    'Loko Gorna / Levski: 1-4',
    'Litex / Loko Gorna: 0-0',
    'Beroe / Botev Plovdiv: 2-1',
    'Loko Gorna / Beroe: 3-1',
    'Pavlikeni / Ludogorets: 0-2',
    'Loko Sofia / Litex: 0-2',
    'Pavlikeni / Marek: 1-1',
    'Litex / Levski: 0-0',
    'Beroe / Litex: 3-2',
    'Litex / Beroe: 1-0',
    'Ludogorets / Litex: 3-0',
    'Litex / Ludogorets: 1-0',
    'CSKA / Beroe: 1-0',
    'Botev Plovdiv / CSKA: 1-1',
    'Ludogorets / Loko Sofia: 1-0',
    'Litex / CSKA: 0-1',
    'Marek / Haskovo: 0-1',
    'Levski / Loko Gorna: 1-1',
    'levski / loko gorna: 5-4'
];
solve(arr);