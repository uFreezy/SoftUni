/**
 * Created by ufree on 2/11/2016.
 */

var specialConsole = (function(){

    function parsePlaceholders(str){
        var regExp = new RegExp("\\{\\d+\\}","g");

        var matches = str.match(regExp);
        if(matches !== null){
            var placeholderVals = [];

            for(var i = 0; i < matches.length; i++){
                placeholderVals.push(matches[i][1]);
            }

            return placeholderVals;
        }

        return false;
    }

    function parseMessage(){
        var args = arguments[0];
        var str = args[0];

        if(parsePlaceholders(str) !== false){
            var placeholders = parsePlaceholders(str);

            for(var i = 0; i < placeholders.length; i++){
                var entity = args[parseInt(placeholders[i]) + 1];

                if(entity !== undefined){
                    str =  str.replace("{"+ placeholders[i] +"}", entity.toString());
                }
                else {
                    str =  str.replace("{"+ placeholders[i] +"}", "");
                }
            }
        }
        return str;
    }

    return{
        writeLine: function(){
            var message = parseMessage(arguments);

            console.log(message);
        },
        writeError: function(){
            var message = parseMessage(arguments);

            console.error(message);
        },
        writeWarning: function(){
            var message = parseMessage(arguments);

            console.warn(message);
        },
        writeInfo: function(){
            var message = parseMessage(arguments);

            console.info(message);
        }

    }
})();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Object: {0}", { name: "Gosho", toString: function() { return this.name }});
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
specialConsole.writeInfo("Info: {0}", "Hi there! Here is some info for you.");
