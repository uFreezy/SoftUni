/**
 * Created by Freezyy on 4/3/2015.
 */
function solve(arr) {
    var output = {};

    arr.sort(function(a,b){
        var aSplit = a.split(' ');
        var bSplit = b.split(' ');

        if(aSplit[1] < bSplit[1]) return -1;
        if(aSplit[1] > bSplit[1]) return 1;
        return 0;
    });

    for(var i = 0; i < arr.length; i++) {
        var line = arr[i].split(' ');
        var curObj = {};

        if(Object.keys(output).indexOf(line[1]) <= -1) {
            var array = [];
            array.push(line[0]);
            curObj.files = array;
            curObj.memory = parseFloat(line[2]).toFixed(2);
            output[line[1]] = curObj;
            curObj = {};
        }
        else {
            output[line[1]].files.push(line[0]);
            output[line[1]].files.sort();
            output[line[1]].memory = (parseFloat(output[line[1]].memory) + parseFloat(line[2])).toFixed(2);
        }
    }
    console.log(JSON.stringify(output));
}

var arr = [
    'sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB'
];
solve(arr);