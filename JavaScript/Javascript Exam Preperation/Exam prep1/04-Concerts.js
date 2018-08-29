/**
 * Created by Freezyy on 3/22/2015.
 */
function solve(arr) {
    var arrayHolder = [];
    for(var string in arr) {
        var tempArray = arr[string].split('|');
        tempArray.splice(2,1);
        for(var i =0;i<tempArray.length;i++){
            tempArray[i] = tempArray[i].trim();
        }
        arrayHolder.push(tempArray);
    }
    function clone(obj) {
        if (null == obj || "object" != typeof obj) return obj;
        var copy = obj.constructor();
        for (var attr in obj) {
            if (obj.hasOwnProperty(attr)) copy[attr] = obj[attr];
        }
        return copy;
    }
    Array.prototype.contains = function(obj) {
        var t = this.length;
        while (t--) {
            if (this[t] === obj) {
                return true;
            }
        }
        return false;
    };
    function cmp(a, b){
        var city1 = a[1];
        var city2 = b[1];

        if(city1<city2)return -1;
        if(city1>city2)return 1;

        var place1 = a[2],
            place2 = b[2];

        if(place1 < place2)return -1;
        if(place1 > place2)return 1;

        var band1 = a[0],
            band2 = b[0];

        if(band1 < band2) return -1;
        if(band1 > band2) return 1;

        return 0;

    }
    arrayHolder.sort(cmp);
    var obj = {};

    var placeObj = {};
    var bandArr = [];
    placeObj[arrayHolder[0][2]] = [];
    var city = arrayHolder[0][1];

    for(i=0;i<arrayHolder.length;i++){
        var curPlace = arrayHolder[i][2],
            curCity = arrayHolder[i][1];

        if(curCity != city){
            obj[city] = clone(placeObj);
            placeObj = {};
            placeObj[curPlace] = [];
            city = curCity;
            //console.log(city);
        }
        if(placeObj.hasOwnProperty(curPlace)){
            if(!placeObj[curPlace].contains(arrayHolder[i][0]))
                placeObj[curPlace].push(arrayHolder[i][0]);
        }
        else{
            placeObj[curPlace] = [];
            placeObj[curPlace].push(arrayHolder[i][0]);
        }
    }
    obj[city] = clone(placeObj);
    //console.log(arrayHolder);
    return (JSON.stringify(obj));

}
/*
 {
 "Buenos Aires": {
 "River Plate Stadium": ["Iron Maiden"]
 },
 "London": {
 "Olympic Stadium": ["Metallica"],
 "Wembley Stadium": ["Helloween", "Iron Maiden", "Twisted Sister", "ZZ Top"]
 },
 "Sofia": {
 "Lokomotiv Stadium": ["Iron Maiden", "Metallica"],
 "Vassil Levski Stadium": ["Helloween", "Iron Maiden"]
 }
 }
 */

//arr =[
//    'ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
//    'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
//    'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
//    'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
//    'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
//    'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
//    'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
//    'Helloween | London | 28-Jul-2014 | Wembley Stadium',
//    'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
//    'Metallica | London | 03-Oct-2014 | Olympic Stadium',
//    'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
//    'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium'
//
//];
//solve(arr);
