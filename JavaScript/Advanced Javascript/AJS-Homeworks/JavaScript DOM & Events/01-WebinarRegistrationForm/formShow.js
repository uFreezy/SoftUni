/**
 * Created by ufree on 2/13/2016.
 */

var checkbox = document.getElementById("check");
checkbox.addEventListener("click",showSpec,false);

function showSpec() {
    if(document.getElementById('specfields').style.display === 'inline-block') {
        document.getElementById('specfields').style.display = 'none'
    }
    else {
        document.getElementById('specfields').style.display = 'inline-block';
    }

}