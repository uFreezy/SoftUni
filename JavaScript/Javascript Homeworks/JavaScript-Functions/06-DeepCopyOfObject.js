/**
 * Created by Freezyy on 3/24/2015.
 */
function clone(obj) {
    var temp  = obj.constructor();

    if(obj == null || typeof(obj) != 'object') {
        return obj;
    }
    for(var key in obj) {
        if(obj.hasOwnProperty(key)) {
            temp[key] = clone(obj[key]);
        }
    }
    return temp;
}
function compareObjects(obj, newObj) {
    var isSame = Object.is(obj,newObj);
    return isSame;
}

var a = {name: 'Pesho', age: 21};
var b = clone(a); // a deep copy
console.log(compareObjects(a, b));

