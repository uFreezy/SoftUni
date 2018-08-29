/**
 * Created by ufree on 2/28/2016.
 */

$('#submit').on('click', function () {
    var className = $('#className').val();
    var color = $('#classColor').val();

    $('.' + className).css('background-color', color);
});