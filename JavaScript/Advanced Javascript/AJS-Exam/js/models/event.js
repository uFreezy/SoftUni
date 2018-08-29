var app = app || {};

(function (eventsSystem) {
    var eventConstr = function (options){
        this._title = this.setTitle(options.title);
        this._type = this.setType(options.type);
        this._duration = this.setDuration(options.duration);
        this._date = this.setDate(options.date);
    };

    eventConstr.prototype = {
        getTitle: function(){
            return this._title;
        },
        setTitle: function(title){
            if(/^[a-zA-Z\s*]+$/.test(title)){
                return title;
            }
            else {
                throw new Error('Title\'s name should countain only letters and whitespace');
            }
        },
        getType: function(){
            return this._type;
        },
        setType: function(type){
            if(/^[a-zA-Z\s*]+$/.test(type)){
                return type;
            }
            else {
                throw new Error('Title\'s type should countain only letters and whitespace');
            }
        },
        getDuration: function(){
            return this._duration;
        },
        setDuration: function(duration){
            if(typeof duration === 'number'){
                return  duration
            }
            else{
                throw new Error('Event\'s duration must be a valid integer.');
            }
        },
        getDate: function(){
            return this._date;
        },
        setDate: function(date){
            if(date instanceof Date){
                return date;
            }
            else{
                throw new Error('Event\'s date must be a valid Date object.');
            }
        }

    };

    eventsSystem._Event = eventConstr;
    eventsSystem.event = function(options){
        if(this.constructor.name === 'Object'){
            throw new Error("Cannot create instance of abstract class Event.");
        }
        return new eventConstr(options);
    }
})(app);