/**
 * Created by ufree on 2/10/2016.
 */

function testContext(){
    console.log(this);
}

function holder(arg){
    arg();
}

testContext();
holder(testContext);

var obj = new testContext();
obj.constructor.call();