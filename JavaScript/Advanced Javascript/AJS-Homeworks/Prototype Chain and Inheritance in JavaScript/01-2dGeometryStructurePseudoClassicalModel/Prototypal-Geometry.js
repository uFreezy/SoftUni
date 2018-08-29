/**
 * Created by ufree on 2/15/2016.
 */

//Creates custom obj.create in case its not supported.
if (!Object.create) {
    Object.create = function (proto) {
        function F() {}
        F.prototype = proto;
        return new F();
    };
}

// Custom extend.
Object.prototype.extend = function(properties) {
    function f() {};
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
};

var Point = {
    init: function(x, y){
        this._x = x;
        this._y = y;
        return this;
    }
};

var Shape = {
    init: function(points, color){
        this._points = points;
        this._color = color;

        Shape._validateObj();
        return this;
    },
    _validateObj: function(){
        console.log(this.name);
        if(this.constructor === Shape){
            throw new Error("Shape is abstract pseudo-class!");
        }
    },
    toString: function(){
        var str =  "Shape name: " + this.constructor+ "\n"; // TODO: Fix constructor name.

        if(this._points instanceof  Array){
            for(var i = 0; i < this._points.length; i++){
                str += "Point: X = " + this._points[i]._x + " Y = " + this._points[i]._y + "\n";
            }
        }
        else {
            str += "Point: X = " + this._points._x + " Y = " + this._points._y + "\n";
        }

        if(typeof this._color !== 'undefined'){
            str += "Color: " + this._color + '\n';
        }

        return str;
    }
};

var Circle = Shape.extend({
    init: function(points, color, radius){
        this._super.init.call(this, points, color);
        this._radius = radius;
        return this;
    }

});

var Triangle = Shape.extend({
    init: function(point, color, height, width){
        this._super.init.call(this, point, color);
        this._height = height;
        this._width = width;
        return this;
    }
});
Triangle.toString = function(){
    var str = this._super.toString.call(this);
    str += "Hello world \n";
    return str;
};

var Line = Shape.extend({
    init: function(points, color){
        this._super.init.call(this, points, color);
        return this;
    }
});

var Segment = Shape.extend({
    init: function(points, color){
        this._super.init.call(this, points, color);
        return this;
    }
});


function pointInit(x, y){
    var obj = Object.create(Point);
    return obj.init(x, y);
}

var shape = Object.create(Shape);
shape.init(pointInit(6,5), "black");
var circle = Object.create(Circle);
circle.init([pointInit(6,5), pointInit(3,4), pointInit(6,7)], "white", 5);
var triangle = Object.create(Triangle);
triangle.init(pointInit(6,5), "yellow", 6.5, 23);
var line = Object.create(Line);
line.init([pointInit(6,5), pointInit(3,4)], "yellow");
var segment = Object.create(Segment);
segment.init([pointInit(6,5), pointInit(3,4)], "yellow");

console.log(shape.toString());
console.log(circle.toString());
console.log(triangle.toString());
console.log(line.toString());
console.log(segment.toString());


