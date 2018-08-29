var imdb = imdb || {};

(function (scope) {

    var id = 1;

    function Genre(name) {
        this.name = name;
        this._movies = [];
        this._id = id;
        id++;
    }

    Genre.prototype.addMovie = function (movie) {
        this._movies.push(movie);
    };
    Genre.prototype.deleteMovie = function (movie) {
        this._movies.remove(movie)
    };
    Genre.prototype.deleteMovieById = function (id) {
        for (var movie in this._movies) {
            if (movie.id === id) {
                this._movies.remove(movie);
                break;
            }
        }
    };
    Genre.prototype.getMovies = function () {
        return this._movies;
    };

    scope.getGenre = function (name) {
        return new Genre(name);
    }
})(imdb);
