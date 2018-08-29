/**
 * Created by Freezyy on 3/31/2015.
 */
function solve(arr) {
    for(var i=0;i<arr.length;i++){
        //arr[i] = arr[i].split(/\+/).join("");
        arr[i] = arr[i].replace(/%20+/g," ");
        arr[i] = arr[i].replace(/\++/g," ");
        var curLine =  arr[i].split(/\?/);
        for(var k=0;k<curLine.length;k++){
            if(curLine[k].indexOf("=")<0){
                curLine.splice(k, 1);
                k--;
            }
        }
        arr[i] = curLine.join("");
        arr[i] = arr[i].split("&");
    }


    for(i=0;i<arr.length;i++){
        var line="";
        for(k=0;k<arr[i].length;k++){
            var curPair = arr[i][k].split("=");
            if(curPair[1]){
                curPair[0] = curPair[0].trim();
                curPair[1] = curPair[1].trim();
                curPair[1] = curPair[1].replace(/ +/, " ");
            }


            if(arr[i][k]!="") {
                for (var t = k + 1; t < arr[i].length; t++) {
                    var pair = arr[i][t].split("=");
                    if (curPair[0] == pair[0].trim()) {
                        //console.log(pair[1]);
                        pair[1] = pair[1].replace(/ +/, " ");
                        curPair.push(pair[1].trim());
                        arr[i][t] = '';
                    }

                }
            }
            line += curPair[0] + '=[';
            for(var m = 1; m < curPair.length; m++) {
                if(m == curPair.length-1) {
                    line += curPair[m] + ']'
                }
                else {
                    line += curPair[m] + ', ';
                }
            }
            while(line[line.length-1]=="[") line = line.slice(0, line.length-2);

        }
        while(line[line.length-1]=="[") line = line.slice(0, line.length-2);
        console.log(line);
    }
   // console.log(arr);
}

//var arr  = [
//        'foo=%20foo&value=+val&foo+=5+%20+203',
//        'foo=poo%20&value=valley&dog=wow+',
//        'url=https://softuni.bg/trainings/coursesinstances/details/1070',
//        'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php'
//
//    ];
var arr = [
    'http://lotr.wikia.com/wiki/Elves?find=elf&elves=amarie%20%20%20%20nimrodel&elves=gil-galad+galadriel&mortal=harry%20potter&elven=legolas&mortal=he-who-must-not-be-named+&mortal=boromir&immortal=spirit&mortal=bilbo+beggins&evil=sauron&answer%20of%20everything++++=42',
    'https://www.google.bg/search?q=whitespace&oq=whitespace&aqs=chrome.0.0l6.1165j0j7&sourceid=chrome&es_sm=93&ie=UTF-8',
    'numbers=20&symbols=#%*^(^('

];

solve(arr);