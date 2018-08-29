/**
 * Created by ufree on 2/28/2016.
 */
var element =  $('<h3>Whoop!</h3>');

$('#before').on('click', function () {
    $('#list').prepend(element);
});

$('#after').on('click', function () {
    $('#list').append(element);
});