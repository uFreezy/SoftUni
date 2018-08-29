/**
 * Created by Freezyy on 3/18/2015.
 */
function group(groupBy) {
    var persons = [
        new Person("Scott", "Guthrie", 38),
        new Person("Scott", "Johns", 36),
        new Person("Scott", "Hanselman", 39),
        new Person("Jesse", "Liberty", 57),
        new Person("Jon", "Skeet", 38)
    ];
    var people = {};

    for(var i = 0; i < persons.length; i++) {
        if(groupBy === 'firstname') {
            people['Group' + ' ' + persons[i].name] = [];
        }
        else if (groupBy === 'lastname') {
            people['Group' + ' ' + persons[i].lastname] = [];
        }
        else {
            people['Group' + ' ' + persons[i].age] = [];
        }

    }
    for(i = 0; i < persons.length; i++) {
        if(groupBy === 'firstname') {
            people['Group' + ' ' + persons[i].name].push(persons[i].name + ' ' + persons[i].lastname + '(age ' + persons[i].age + ")");
        }
        else if (groupBy === 'lastname') {
            people['Group' + ' ' + persons[i].lastname].push(persons[i].name + ' ' + persons[i].lastname + '(age ' + persons[i].age + ")");
        }
        else {
            people['Group' + ' ' + persons[i].age].push(persons[i].name + ' ' + persons[i].lastname + '(age ' + persons[i].age + ")");
        }
    }
    for(ele in people) {
        people[ele] = people[ele].join();
    }
    console.log(people);
}
function Person(name,lastname,age) {
    this.name = name;
    this.lastname = lastname;
    this.age = age;
}
group('name');

