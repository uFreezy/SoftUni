/**
 * Created by ufree on 2/10/2016.
 */

function printArgsInfo(){

   for(var i = 0; i < arguments.length; i++){
       var argType = typeof arguments[i];

       if(Array.isArray(arguments[i])){
           argType = "array";
       }

       console.log(arguments[i] + " (" + argType + ")");
   }
}
console.log("----- Problem 1 -----");
printArgsInfo(2, 3, 2.5, -110.5564, false);
printArgsInfo(null, undefined, "", 0, [], {});

console.log("----- Problem 2 -----");
printArgsInfo.call(undefined);
printArgsInfo.call(undefined, 2, 3, 2.5, -110.5564, false);

printArgsInfo.apply();
printArgsInfo.apply(undefined,[2, 3, 2.5, -110.5564, false]);

