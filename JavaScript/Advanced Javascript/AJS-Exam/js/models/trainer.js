var app = app ||{};

//Creates custom .extends func.
Function.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

(function (eventsSystem) {
    function Trainer(name, workHours){
        eventsSystem._Employee.call(this, name, workHours);
        this.courses = [];
        this.feedbacks = [];
    }
    Trainer.extends(eventsSystem._Employee);

    Trainer.prototype.addFeedback = function(feedback){
        if(typeof feedback !== 'string'){
            throw new Error("Feedback must be string");
        }
        this.feedbacks.push(feedback);
    };

    Trainer.prototype.addCourse = function(course){
        if(course.constructor.name !== 'Course'){
            throw new Error("addCourse accepts only objects of type Course");
        }

        this.courses.push(course);
    };

    eventsSystem.trainer = function (name, workHours) {
        return new Trainer(name, workHours);
    }
})(app);