/**
 * Created by Freezyy on 4/5/2015.
 */
function solve(arr) {
    var coinsAmount = 0,
        bronzeCoins = 0,
        silverCoins = 0,
        goldCoins = 0;

    for(var value in arr) {
        var coinValue = arr[value].split(' ');

        if(coinValue[0].toLowerCase() == 'coin' && !isNaN(parseInt(coinValue[1]))
            && parseFloat(coinValue[1]) % 1 == 0 && parseInt(coinValue[1]) > 0) {
            coinsAmount += parseInt(coinValue[1]);

        }
    }
    //console.log(coinsAmount);
    while(coinsAmount >= 100) {
        goldCoins++;
        coinsAmount -= 100;
    }
    while(coinsAmount >= 10) {
        silverCoins++;
        coinsAmount -= 10;
    }
    while(coinsAmount > 0) {
        bronzeCoins++;
        coinsAmount -= 1;
    }
    console.log('gold : ' + goldCoins);
    console.log('silver : ' + silverCoins);
    console.log('bronze : ' + bronzeCoins);

}

var arr = [
    'coin gosho',
    'coin 5.56',
    'coin 10',
    'coin 20',
    'coin 50',
    'coin 100',
    'coin 200',
    'coin -500',
    'cigars 500'

];
solve(arr);