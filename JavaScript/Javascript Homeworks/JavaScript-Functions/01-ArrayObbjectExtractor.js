/**
 * Created by Freezyy on 3/21/2015.
 */
function extractObjects(array) {
    var cleanArray = [];

    for(var index in array) {
        if(typeof array[index] == 'object' && !Array.isArray(array[index])) {
            cleanArray.push(array[index]);
        }
    }
    console.log(cleanArray);
}


var array = [
    "Pesho",
    4,
    4.21,
    { name : 'Valyo', age : 16 },
    { type : 'fish', model : 'zlatna ribka' },
    [1,2,3],
    "Gosho",
    { name : 'Penka', height: 1.65}
];
extractObjects(array);
