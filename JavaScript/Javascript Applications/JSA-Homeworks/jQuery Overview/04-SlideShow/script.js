/**
 * Created by ufree on 2/28/2016.
 */


var slideshow = $('.slideshow > div');
var slidesCount = slideshow.length;
var counter = 0;

$('.previous').on('click', function () {
    if (counter === 0) {
        counter = slidesCount - 1;
    }
    else {
        counter--;
    }
    changeSlide();
});

$('.next').on('click', function () {
    if(counter === slidesCount){
        counter = 0;
    }
    else {
        counter++;
    }
    changeSlide();
});

startSlideshow();
function startSlideshow() {
    changeSlide();
    window.setInterval(function () {
        counter++;
        changeSlide();
    }, 5000);
}

function changeSlide() {
    slideshow.css('display', 'none');
    if (counter === slidesCount) {
        counter = 0;
    }
    slideshow.eq(counter).fadeIn(500);
}