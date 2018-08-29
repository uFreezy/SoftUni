/**
 * Created by ufree on 2/18/2016.
 */


String.prototype.startsWith = function(pattern){

    var str = this;

    //console.log(typeof pattern);
    if(typeof pattern !== 'string'){
        throw new Error("startsWith needs string in order to work correctly.");
    }
    return str.slice(0,pattern.length) == pattern;


};
String.prototype.endsWith = function(pattern){
    var str = this;

    if(typeof pattern !== 'string'){
        throw new Error("endsWith needs string in order to work correctly.");
    }
    return str.slice(str.length - pattern.length, str.length) == pattern;
};
String.prototype.left = function(count){
    var str = this;

    if(count > str.length){
        return str.toString();
    }

    return str.slice(0, count).toString();
};
String.prototype.right = function(count){
    var str = this;

    if(count > str.length){
        return str.toString();
    }

    return str.slice(str.length - count, str.length);
};
String.prototype.padLeft = function(count, char){
    if(char === undefined){
        char = ' ';
    }
    var charString = (new Array(count + 1).join(char)).toString();
    return charString + this;
};
String.prototype.padRight = function(count, char){
    if(char === undefined){
        char = ' ';
    }

    var charString = (new Array(count + 1).join(char)).toString();

    return this + charString;
};
String.prototype.repeat = function(count){
    return new Array(count + 1).join(this).toString();
};

var startExample = "This is an startExample string used only for demonstration purposes.";
console.log(startExample.startsWith("This"));
console.log(startExample.startsWith("this"));
console.log(startExample.startsWith("other"));

var endExample = "This is an startExample string used only for demonstration purposes.";
console.log(endExample.endsWith("poses."));
console.log(endExample.endsWith ("startExample"));
console.log(endExample.startsWith("something else"));

var leftExample = "This is an leftExample string used only for demonstration purposes.";
console.log(leftExample.left(9));
console.log(leftExample.left(90));

var rightExample = "This is an rightExample string used only for demonstration purposes.";
console.log(rightExample.right(9));
console.log(rightExample.right(90));

// Combinations must also work
var example = "abcdefgh";
console.log(example.left(5).right(2));

var hello = "hello";
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, "."));
console.log(hello.padLeft(10, "."));
console.log(hello.padLeft(2, "."));

console.log(hello.padRight(5));
console.log(hello.padRight(10));
console.log(hello.padRight(5, "."));
console.log(hello.padRight(10, "."));
console.log(hello.padRight(2, "."));

var character = "*";
console.log(character.repeat(5));
// Alternative syntax
console.log("~".repeat(3));

// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));

