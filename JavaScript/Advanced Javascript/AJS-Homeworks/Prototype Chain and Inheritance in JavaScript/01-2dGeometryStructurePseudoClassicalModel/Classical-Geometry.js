/**
 * Created by ufree on 2/13/2016.
 */

//Creates custom obj.create in case its not supported.
if (!Object.create) {
    Object.create = function (proto) {
        function F() {}
        F.prototype = proto;
        return new F();
    };
}

//Creates custom .extends func.
Object.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};


var Point = (function(){
    function Point(x, y){
        this._x = x;
        this._y = y;
    }

    return Point;
})();

var Shape = (function(){

    if (this.constructor === Shape) {
        throw new Error("Can't instantiate abstract class!");
    }

    function Shape(points, color){
        this._points = points; // Array of points.
        this._color = color;
    }

    Shape.prototype.toString = function() {
        var str =  "Shape name: " + this.constructor.name + "\n";

        if(this._points instanceof  Array){
            for(var i = 0; i < this._points.length; i++){
                str += "Point: X = " + this._points[i]._x + " Y = " + this._points[i]._y + "\n";
            }
        }
        else {
            str += "Point: X = " + this._points._x + " Y = " + this._points._y + "\n";
        }

        str += "Color: " + this._color + '\n';

        return str;
    };

    return Shape;
})();

var Circle = (function(){
    function Circle(a, radius,color){
        Shape.call(this, a, color);
        this._radius = radius;
    }

    Circle.extends(Shape);

    Circle.prototype.toString = function(){
        var str = Shape.prototype.toString.call(this);
        str += "Radius: " + this._radius + "\n";

        return str;
    };

    return Circle;
})();

var Triangle = (function(){
    function Triangle(a, b, c, color){
        Shape.call(this, [a, b, c], color);
    }

    Triangle.extends(Shape);

    return Triangle;
})();

var Line = (function(){
    function Line(a, b, color){
        Shape.call(this, [a, b], color);
    }

    Line.extends(Shape);

    return Line;
})();

var Segment =(function(){
    function Segment(a, b, color){
        Shape.call(this, [a, b], color);
    }

    Segment.extends(Shape);

    return Segment;
})();

var circle = new Circle( new Point(6,7), 5, "#eceec7");
var triangle = new Triangle( new Point(4,5), new Point(6,7), new Point(1,9),"#eceec7");
var line = new Line( new Point(5,6), new Point(3,6), "#eceec45");
var segment = new Segment( new Point(5,6), new Point(3,6), "#eceec45");

console.log(circle.toString());
console.log(triangle.toString());
console.log(line.toString());
console.log(segment.toString());

