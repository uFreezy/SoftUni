/**
 * Created by Freezyy on 3/17/2015.
 */
function slove(input) {
    var cleanArray = [],
        minNumb,
        maxNumb,
        mostFreq;
    input.forEach(function (ele){
        if(!isNaN(ele)) {
            cleanArray.push(ele);
        }
    });
    cleanArray = cleanArray.sort(function (a, b) {
        return a - b;
    });
    minNumb = cleanArray[0];
    maxNumb = cleanArray[cleanArray.length - 1];
    mostFreq = calcMostFreq(cleanArray);
    console.log("Min number: " + minNumb);
    console.log("Max number: " + maxNumb);
    console.log("Most frequent number: " + mostFreq);
    console.log(cleanArray.reverse());



    function calcMostFreq (array) {
        var currentCount = 1,
            biggestCount = 0,
            mostFreq;
        for (var i = 0; i < array.length; i++) {
            if (array[i] === array[i+1] && i+1 < array.length) {
                currentCount++;
            }
            else {
                currentCount = 1;
            }
            if (currentCount > biggestCount) {
                biggestCount = currentCount;
                mostFreq = array[i];
            }
        }
        return mostFreq;
    }
}
slove(input = ["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount : 10}, [10, 20, 30, 40]]);