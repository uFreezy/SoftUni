var app = app || {};

(function (eventSystem) {
    function Employee(name, workHours){
        this._name = name;
        this._workHours = workHours;
    }

    eventSystem._Employee = Employee;
    eventSystem.employee = function(name, workHours){
        return new Employee(name,workHours);
    }
})(app);