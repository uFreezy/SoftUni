//TODO: Implement hall module
var app = app || {};

(function (eventsSystem) {
    function Hall(name, capacity){
        this._name = this.setName(name);
        this._capacity = this.setCapacity(capacity);
        this.parties = [];
        this.lectures = [];
    }

    Hall.prototype = {
        getName: function(name){
            return name;
        },
        setName: function(name){
            if(/^[a-zA-Z\s*]+$/.test(name)){
                return name;
            }
            else{
                throw new Error('Hall\'s name must contain only chars and whitespace');
            }
        },
        getCapacity: function(){
            return this._capacity;
        },
        setCapacity: function(capacity){
            if(typeof capacity === 'number'){
                return this._capacity = capacity;
            }
            else{
                throw new Error("Hall\'s capacity must be a valid integer.");
            }
        }
    };

    Hall.prototype.addEvent = function (event) {
        if(event.constructor.name === 'Party'){
            this.parties.push(event);
        }
        else if(event.constructor.name === 'Lecture'){
            this.lectures.push(event);
        }
    };

    eventsSystem.hall = function hall(name, capacity){
        return new Hall(name, capacity);
    }
})(app);