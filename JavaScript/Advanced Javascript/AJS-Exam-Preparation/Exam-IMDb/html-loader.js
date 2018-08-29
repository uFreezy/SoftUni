var imdb = imdb || {};

(function (scope) {
    function loadHtml(selector, data) {
        var container = document.querySelector(selector),
            moviesContainer = document.getElementById('movies'),
            detailsContainer = document.getElementById('details'),
            genresUl = loadGenres(data);

        container.appendChild(genresUl);

        genresUl.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'LI') {
                var genreId,
                    genre,
                    moviesHtml;

                genreId = parseInt(ev.target.getAttribute('data-id'));
                genre = data.filter(function (genre) {
                    return genre._id === genreId;
                })[0];

                moviesHtml = loadMovies(genre.getMovies());
                moviesContainer.innerHTML = moviesHtml.outerHTML;
                moviesContainer.setAttribute('data-genre-id', genreId);
            }
        });

        var moviesDiv = document.querySelector('#movies');

        moviesDiv.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'LI' || ev.target.parentElement.tagName === 'LI') {
                for(var m = 1; m < moviesDiv.childNodes.length; m++){
                    var child = moviesDiv.childNodes[m];
                    moviesDiv.removeChild(child);
                }
                var movieId  = ev.target.getAttribute('data-id') || ev.target.parentElement.getAttribute('data-id');
                var genres = imdb.getGenres();

                for(var i = 0; i < genres.length; i++){
                    //console.log(genres[i]);
                    var movies = genres[i].getMovies();

                    for(var j = 0; j < movies.length; j++){
                        if(movies[j]._id === parseInt(movieId)){
                            moviesDiv.appendChild(bindActors(movies[j]));
                        }
                    }
                }
            }
        }, false);


        function bindActors(node){
            var innerUl = document.createElement('UL');
            var header = document.createElement('H3');
            header.innerHTML = 'Actors';
            innerUl.appendChild(header);


            var actors = node.getActors();
            for(var i = 0; i < actors.length; i++){
                var div = document.createElement('DIV');
                var bioLi = document.createElement('LI');
                var bornLi = document.createElement('LI');
                var h4 =  document.createElement('H4');
                h4.innerHTML = actors[i].name;
                var bio = document.createElement('P');
                bio.innerHTML = '<strong> Bio: </strong>' + actors[i].bio;
                var born = document.createElement('P');
                born.innerHTML = '<strong> Born: </strong>' + actors[i].born;
                
                bioLi.appendChild(bio);
                bornLi.appendChild(born);
                div.appendChild(h4);
                div.appendChild(bioLi);
                div.appendChild(bornLi);
                innerUl.appendChild(div);
            }

            return innerUl;
        }
        // Task 2 - Add event listener for movies boxes

        // Task 3 - Add event listener for delete button (delete movie button or delete review button)
    }

    function loadGenres(genres) {
        var genresUl = document.createElement('ul');
        genresUl.setAttribute('class', 'nav navbar-nav');
        genres.forEach(function (genre) {
            var liGenre = document.createElement('li');
            liGenre.innerHTML = genre.name;
            liGenre.setAttribute('data-id', genre._id);
            genresUl.appendChild(liGenre);
        });

        return genresUl;
    }

    function loadMovies(movies) {
        var moviesUl = document.createElement('ul');
        movies.forEach(function (movie) {
            var liMovie = document.createElement('li');
            liMovie.setAttribute('data-id', movie._id);

            liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
            liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
            liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
            liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
            liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
            liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';

            moviesUl.appendChild(liMovie);
        });

        return moviesUl;
    }

    scope.loadHtml = loadHtml;
}(imdb));