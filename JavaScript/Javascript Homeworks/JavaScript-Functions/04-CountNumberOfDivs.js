/**
 * Created by Freezyy on 3/23/2015.
 */
function countDivs(string) {
    var matchedValues = string.match(/<div/g);
    console.log(matchedValues.length);
}

var html = '<!DOCTYPE html>' +
    '<html>' +
    '<head lang="en">' +
    '<meta charset="UTF-8">' +
    '<title>index</title>' +
    '<script src="/yourScript.js" defer></script>' +
    '</head>' +
    '<body>' +
    '<div id="outerDiv">' +
    '<div ' +
    'class="first"> ' +
    '<div><div>hello</div></div>' +
    '</div>' +
    '<div>hi<div></div></div>' +
    '<div>I am a div</div>' +
    '</div>' +
    '</body>' +
    '</html>';

countDivs(html);