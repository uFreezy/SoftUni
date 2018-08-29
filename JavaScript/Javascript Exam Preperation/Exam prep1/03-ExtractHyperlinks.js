/**
 * Created by Freezyy on 3/19/2015.
 */
function solve(args) {
    var str = "",
        links = [];

    for(var string in args) {
        str += args[string];
    }
    str =  str.replace(/\s/g,''); // removes all the whitespaces
    var tagA = str.match(/<a[^>]+>/g); // returns array of the matched values

    for(var index in tagA) {
        if(tagA[index].match(/href\s*=\s*"[^"]+"/g) ) {
            links.push(tagA[index].match(/href\s*=\s*"[^"]+"/g).toString());
        }
        else if (tagA[index].match(/href\s*=\s*'[^']+'/g)) {
            links.push(tagA[index].match(/href\s*=\s*'[^']+'/g).toString());
        }
    }
    for(var link in links) {
        if(links[link].match(/="[^"]+"/g)) {
            console.log(links[link].match(/="[^"]+"/g).toString().replace(/(=")|"/g, ''));
        }
        else if(links[link].match(/='[^']+'/g)) {
            console.log(links[link].match(/='[^']+'/g).toString().replace(/(=')|'/g, ''));
        }
    }
    console.log(tagA);
}

//var args = [];
//args.push('http://www.nakov.com class=new>nak</a></li></ul>');
//args.push('<a href="#empty"></a>');
//args.push('<a href="#commented">commentex hyperlink</a> -->');
//args.push('<ul><li><a   href="/"  id="home">Home</a></li><li><a');
//args.push('</li><li><a href = ');
//args.push("'/forum' >Forum</a></li><li><a class=href ");
//args.push('<a id="href">href="fake"<img src=""');
//args.push('alt="abv"/></a><a href="#">&lt;a href="hello"&gt;</a>');
//
//solve(args);