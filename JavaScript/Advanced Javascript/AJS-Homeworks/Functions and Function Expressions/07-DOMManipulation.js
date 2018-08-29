/**
 * Created by ufree on 2/10/2016.
 */
var domModule = (function(){
    function parser(ele,isSingle){
        if(typeof ele  === "string" && isSingle){
            return document.querySelector(ele);
        }
        else if(typeof ele === "string" && !isSingle){
            return document.querySelectorAll(ele);
        }
        else {
            return ele;
        }
    }

    return{
        appendChild: function(element, parent){
            var parentVal = parser(parent,true);
            var elementVal = parser(element,true);

            parentVal.appendChild(elementVal);
        },
        removeChild: function(element, child){
            var parent = parser(element,true);
            var childToRemove = parser(child,true);

            parent.removeChild(childToRemove);
        },
        addHandler: function(element, eventType, eventHandler){
            var ele = parser(element,false);

            for(var i = 0; i < ele.length; i++){
                ele[i].addEventListener(eventType,eventHandler);
            }
        },
        retriveElements: function(selector){
            var elements = parser(selector,false);

            /*
            * Left here for testing purposes.
            * */
            console.log(elements);
        }
    }
})();

