/**
 * Created by Freezyy on 3/17/2015.
 */
function slove (input) {
    var cleanArray = [];

    for (var ele in input) {
        if (input[ele] < 400 && input[ele] > 0) {
            if(input[ele]*0.8 % 1 === 0) {
                cleanArray.push(input[ele]*0.8);
            }
            else {
                cleanArray.push((input[ele]*0.8).toFixed(1));
            }
        }
    }
    console.log(cleanArray.sort(function (a, b) {
        return a - b;
    }));

}

slove(input = [200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);