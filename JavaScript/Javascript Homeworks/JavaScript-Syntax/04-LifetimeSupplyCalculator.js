/**
 * Created by Freezyy on 3/14/2015.
 */

var Person1 = {
    age: 38,
    maxAge: 118,
    typeFood: "chocolate",
    foodPerDay: 0.5
};
var Person2 = {
    age: 20,
    maxAge: 87,
    typeFood: "fruits",
    foodPerDay: 2
};
var Person3 = {
    age: 16,
    maxAge: 102,
    typeFood: "nuts",
    foodPerDay: 1.1
};

calcSupply(Person1.age, Person1.maxAge, Person1.typeFood, Person1.foodPerDay);
calcSupply(Person2.age, Person2.maxAge, Person2.typeFood, Person2.foodPerDay);
calcSupply(Person3.age, Person3.maxAge, Person3.typeFood, Person3.foodPerDay);

function calcSupply(age, maxAge, typeFood, foodPerDay) {
    var supply = 0;
    for(var i = 0; i < maxAge-age; i++) {
        supply += foodPerDay*365;
    }
    console.log(supply.toFixed(0) + "kg" + " of " + typeFood + " would be enough until I am " + maxAge + " years old.");
}
