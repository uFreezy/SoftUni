/**
 * Created by Freezyy on 3/17/2015.
 */
function replaceATag (str) {
    var strA = str.substring(str.search("<a")).replace(">","]"),
        re = new RegExp('>', 'g');

    str = str.slice(0, str.search("<a"));
    str += strA;
    str = str.replace("<a", "[URL");
    str = str.replace("</a>", "[/URL]\n");
    str = str.replace(re, ">\n");
    console.log(str);
}

replaceATag('<ul>' +
' <li>' +
'  <a href=http://softuni.bg>SoftUni</a>'+
' </li>'+
'</ul>'
);
