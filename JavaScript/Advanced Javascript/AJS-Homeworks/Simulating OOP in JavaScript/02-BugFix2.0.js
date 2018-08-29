/**
 * Created by ufree on 2/17/2016.
 */


function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.fullName = firstName + " " + lastName;
}

Person.prototype = {
    get fullName() {
        return this.firstName + " " + this.lastName;
    },

    set fullName(name) {
        var names = name.split(" ");
        this.firstName = names[0];
        this.lastName = names[1];
    }
};

var person = new Person("Peter", "Jackson");
// Getting values
console.log(person.firstName);
console.log(person.lastName);
console.log(person.fullName);
// Changing values
person.firstName = "Michael";
console.log(person.firstName);
console.log(person.fullName);
person.lastName = "Williams";
console.log(person.lastName);
console.log(person.fullName);
// Changing the full name should work too
person.fullName = "Alan Marcus";
console.log(person.fullName);
console.log(person.firstName);
console.log(person.lastName);
