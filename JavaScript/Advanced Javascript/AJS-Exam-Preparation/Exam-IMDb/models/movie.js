var imdb = imdb || {};

(function (scope) {

    var id = 1;

    function Movie(title, length, rating, country) {
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
        this._id = id;
        id++;
    }

    Movie.prototype.addActor = function (actor) {
        this._actors.push(actor);
    };
    Movie.prototype.getActors = function () {
        return this._actors;
    };
    Movie.prototype.addReview = function (review) {
        this._reviews.push(review)
    };
    Movie.prototype.deleteReview = function (review) {
        this._reviews.remove(review);
    };
    Movie.prototype.deleteReviewById = function (id) {
        for (var review in this._reviews) {
            if (review.id === id) {
                this._reviews.remove(review);
                break;
            }
        }
    };
    Movie.prototype.getReviews = function () {
        return this._reviews;
    };

    scope.getMovie = function (title, length, rating, country) {
        return new Movie(title, length, rating, country)
    }
})(imdb);