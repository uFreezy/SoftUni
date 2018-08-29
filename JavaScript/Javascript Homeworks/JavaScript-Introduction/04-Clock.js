/**
 * Created by Freezyy on 3/11/2015.
 */
function getClock() {
    var clock = new Date();
    var h = clock.getHours();
    var m = clock.getMinutes();
    var s = clock.getSeconds();

    document.getElementById('txt').innerHTML = h + ":" + m + ":" + s;
    var t = setTimeout(function(){getClock()},500); // makes the script refresh every 500 milliseconds
}