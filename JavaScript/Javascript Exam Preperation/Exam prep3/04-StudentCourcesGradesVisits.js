/**
 * Created by Freezyy on 4/1/2015.
 */
function solve(arr) {

    var mainObj = {};
    var curObj = {};

    arr.sort(function(a,b) {
        var eleA = a.split('|'),
            eleB = b.split('|');

        for(var i = 0; i < eleA.length; i++) {
            eleA[i] = eleA[i].trim();
            eleB[i] = eleB[i].trim();
        }
        if(eleA[1] < eleB[1]) return -1;
        if(eleA[1] > eleB[1]) return 1;
        return 0;
    });

    var curCourse  = '';
    var addCounter = 0;
    for(var i = 0; i < arr.length; i++) {
        var line = arr[i].split('|');

        for(var indx in line) {
            line[indx] = line[indx].trim();
        }

        if(curCourse != line[1]) {
            if(i != 0) {
                curObj.avgGrade = parseFloat((curObj.avgGrade / addCounter).toFixed(2));
                curObj.avgVisits = parseFloat((curObj.avgVisits / addCounter).toFixed(2));
                curObj.students = curObj.students.sort();
                addCounter = 0;
                mainObj[curCourse] = curObj;
                curObj = {};

            }
            curCourse  = line[1];
            curObj.avgGrade =  parseFloat(line[2]);
            curObj.avgVisits = parseFloat(line[3]);
            curObj.students = [];
            curObj.students.push(line[0]);
            addCounter++;
        }
        else {
            curObj.avgGrade +=  parseFloat(line[2]);
            curObj.avgVisits +=  parseFloat(line[3]);
            if(curObj.students.indexOf(line[0]) <= -1) {
                curObj.students.push(line[0]);
            }
            addCounter++;
        }
        if(i == arr.length-1) {
            if(i != 0 || arr.length == 1) {
                curObj.avgGrade = parseFloat((curObj.avgGrade / addCounter).toFixed(2));
                curObj.avgVisits = parseFloat((curObj.avgVisits / addCounter).toFixed(2));
                curObj.students = curObj.students.sort();
                addCounter = 0;
                mainObj[curCourse] = curObj;
                curObj = {};

            }
            curCourse  = line[1];
            curObj.avgGrade =  parseFloat(line[2]);
            curObj.avgVisits = parseInt(line[3]);
            curObj.students = [];
            curObj.students.push(line[0]);
            addCounter++;
        }
    }
    console.log(JSON.stringify(mainObj));
}

var arr = [
    'Milen Georgiev|PHP|2.02|2',
    'Ivan Petrov | C# Basics | 3.20 | 22',
    'Peter Nikolov | C# | 5.522 | 18',
    'Maria Kirova | C# Basics | 5.40 | 4.5',
    'Stanislav Peev | C# | 4.012 | 15',
    'Ivan Petrov |    PHP Basics     |     5.120 |6',
    'Ivan Goranov | SQL | 5.926 | 12',
    'Todor Kirov | Databases | 5.50 |0.0000',
    'Maria Ivanova | Java | 5.83 | 37',
    'Milena Ivanova |    C# |   1.823 | 4.5',
    'Stanislav Peev   |    C#|   4.122    |    15',
    'Kiril Petrov |PHP| 5.10 | 6',
    'Ivan Petrov|SQL|5.926|3',
    'Peter Nikolov   |    Java  |   5.9996    |    9',
    'Stefan Nikolov | Java | 4.00 | 9.5',
    'Ivan Goranov | SQL | 5.926 | 12.5',
    'Todor Kirov | Databases | 5.150 |0.0000',
    'Kiril Ivanov | Java | 5.083 | 327',
    'Diana Ivanova |    C# |   1.823 | 4',
    'Stanislav Peev   |    C#|   4.122    |    15',
    'Kiril Petrov |PHP| 5.10 | 6'
];

solve(arr);