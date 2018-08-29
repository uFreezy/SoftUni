var app = app || {};

//Creates custom .extends func.
Function.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

(function (eventsSystem) {
    function Lecture(options){
        var base = {
            title: options.title,
            type: options.type,
            duration: options.duration,
            date: options.date
        };
        eventsSystem._Event.call(this,base);
        this._trainer = this.setTrainer(options.trainer);
        this._course = this.setCourse(options.course);
    }
    Lecture.extends(eventsSystem._Event);

    Lecture.prototype = {
        getTrainer: function(){
            return this._trainer;
        },
        setTrainer: function(trainer){
            if(trainer instanceof eventsSystem.trainer){
                return trainer;
            }
            else{
                throw new Error('Object must be of type Trainer.');
            }
        },
        getCoure: function(){
            return this._course;
        },
        setCourse: function(course){
            if(course instanceof eventsSystem.course){
                return course;
            }
            else{
                throw new Error('Object must be of type Course.');
            }
        }
    };

   eventsSystem.lecture = function (options) {
       return new Lecture(options);
   }
})(app);