/**
 * Created by Freezyy on 3/23/2015.
 */
function SortLetters(string, boolean) {
    if (boolean) {
        string = string.split('').sort(function(a,b){
            a = a.toLowerCase();
            b = b.toLowerCase();
            if(a == b) return 0;
            return a < b ? -1 : 1;
        }).join('');
    }
    else {
        string = string.split('').sort(function sortToLower(a,b){
            a = a.toLowerCase();
            b = b.toLowerCase();
            if(a == b) return 0;
            return a < b ? -1 : 1;
        }).reverse().join('');
    }
    console.log(string);
}

SortLetters('HelloWorld',false);