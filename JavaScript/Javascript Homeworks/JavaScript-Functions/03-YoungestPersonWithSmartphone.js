/**
 * Created by Freezyy on 3/23/2015.
 */
function findYoungestPerson(array) {
    var youngest,
        minAge = Number.MAX_VALUE;
    for(var i = 0; i < array.length; i++) {
        if(array[i].age < minAge){
            minAge = array[i].age;
            youngest = array[i].firstname + ' ' + array[i].lastname;
        }
    }
    console.log('The youngest person is '+ youngest);
}

var people = [
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }];

findYoungestPerson(people);
