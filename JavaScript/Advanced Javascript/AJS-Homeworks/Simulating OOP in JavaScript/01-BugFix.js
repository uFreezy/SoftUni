/**
 * Created by ufree on 2/17/2016.
 */

function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.fullName = firstName + " " + lastName;
}

var peter = new Person("Peter", "Jackson");
console.log(peter.fullName);
console.log(peter.firstName);
console.log(peter.lastName);