var imdb = imdb || {};

(function (scope) {

    var id = 1;

    function Theatre(title, length, rating, country, isPuppet) {
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this.isPuppet = isPuppet;
        this._actors = [];
        this._reviews = [];
        this._id = id;
        id++;
    }

    Theatre.prototype.addActor = function (actor) {
        this._actors.push(actor);
    };
    Theatre.prototype.addReview = function (review) {
        this._reviews.push(review);
    };

    scope.getTheatre = function (name, length, rating, country, isPuppet) {
        return new Theatre(name, length, rating, country, isPuppet);
    };
})(imdb);