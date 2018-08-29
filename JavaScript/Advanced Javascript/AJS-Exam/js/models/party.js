var app = app || {};

//Creates custom .extends func.
Function.prototype.extends = function (parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};


(function (eventsSystem) {
    function Party(options){
        var base = {
            title: options.title,
            type: options.type,
            duration: options.duration,
            date: options.date
        };
        eventsSystem._Event.call(this, base);
        this._isCatered = this.setIsCatered(options.isCatered);
        this._isBirthday = this.setIsBirthday(options.isBirthday);
        this._organiser = this.setOrganiser(options.organiser);
    }
    Party.extends(eventsSystem._Event);

    Party.prototype = {
        getIsCatered: function(){
            return this._isCatered;
        },
        setIsCatered: function(isCatered){
            if(typeof isCatered === 'boolean'){
                return isCatered;
            }
            else {
                throw new Error('Value must be bool');
            }
        },
        getIsBirthday: function(){
            return this._isBirthday;
        },
        setIsBirthday: function(isBirthday){
            if(typeof isBirthday === 'boolean'){
                return isBirthday;
            }
            else {
                throw new Error('Value must be bool');
            }
        },
        getOrganiser: function(){
            return this._organiser
        },
        setOrganiser: function(organiser){
            if(organiser instanceof eventsSystem.employee){
                return organiser
            }
            else {
                throw new Error('Organiser must be object of type employee.');
            }
        }
    };

    eventsSystem.party = function (options) {
      return new Party(options);
    };
})(app);