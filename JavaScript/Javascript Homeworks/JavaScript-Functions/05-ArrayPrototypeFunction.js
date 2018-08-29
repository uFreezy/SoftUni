/**
 * Created by Freezyy on 3/24/2015.
 */
Array.prototype.removeItem = function(ele) {
    var output = [];
    for(var value in arr) {
        if(arr[value] !== ele && typeof arr[value] != "function") {
            output.push(arr[value]);
        }
    }
    console.log(output);
};

var arr = ['hi', 'bye', 'hello' ];
arr.removeItem('bye');



