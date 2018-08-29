function solve(arr){

    var mainObj = {};
    var colorName = "";
    arr.sort();
    function processColor(start, end){

        var colorObj = {};
        var opponents = [];
        var wins = 0;
        var losses = 0;

        for(var k = start;k<=end;k++){
            var line = arr[k].split("|");

            if(line[1]=="name") colorObj["name"] = line[2];
            if(line[1]=="age") colorObj["age"] = line[2];
            if(line[1]=="win") {
                opponents.push(line[2]);
                wins++;
            }
            if(line[1]=="loss") {
                opponents.push(line[2]);
                losses++;
            }
        }
        opponents.sort();
        colorObj["opponents"] = opponents;
        colorObj["rank"] = ((wins+1)/(losses+1)).toFixed(2);
        if(colorObj.name && colorObj.age) return colorObj;
        return null;
    }

    for(var i=0;i<arr.length;i++){
        var line = arr[i].split("|");
        colorName = line[0];
        var end = 0;
        for(var j=i+1;j<arr.length;j++){
            var curColor = arr[j].split("|")[0];
            if(curColor != colorName || (j == arr.length-1)){
                if(j==arr.length-1)
                    var colorObj = processColor(i, j);
                else
                    var colorObj = processColor(i, j-1);
                if(colorObj){
                    mainObj[colorName] = colorObj;
                }
                i=j-1;
                break;
            }
        }
    }

    console.log(JSON.stringify(mainObj));

}

var arr = [
    "purple|age|99",
    "red|age|44",
    "blue|win|pesho",
    "blue|win|mariya",
    "purple|loss|Kiko",
    "purple|loss|Kiko",
    "purple|loss|Kiko",
    "purple|loss|Yana",
    "purple|loss|Yana",
    "purple|loss|Manov",
    "purple|loss|Manov",
    "red|name|gosho",
    "red|ops|kaval",
    "blue|win|Vladko",
    "purple|loss|Yana",
    "purple|name|VladoKaramfilov",
    "blue|age|21",
    "blue|loss|Pesho"

];
solve(arr);