/**
 * Created by ufree on 2/18/2016.
 */

Array.prototype.flatten = function(){
    var array = this;
    var processedArray = [];

    for(var i = 0; i < array.length; i++){
        if(array[i] instanceof Array){
            var subArray = array[i].flatten();
            processedArray.push.apply(processedArray,subArray);
        }
        else {
            processedArray[i] = array[i]
        }

    }
    return processedArray;
};

var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
