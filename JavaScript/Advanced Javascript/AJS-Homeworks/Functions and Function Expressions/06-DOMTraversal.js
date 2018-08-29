/**
 * Created by ufree on 2/10/2016.
 */

function childTraversal(selector){
    var sel = selector.substring(1, selector.length);

    var elements = document.getElementsByClassName(sel)[0].childNodes;

    printChildren(elements);

    function printChildren(nodeList){

        for(var i = 0; i < nodeList.length; i++){
            if(nodeList[i].tagName !== undefined) {
                if(arguments[1] !== undefined){
                    var nodeString = arguments[1] +
                        nodeList[i].tagName.toLocaleLowerCase() + ": " ;
                }
                else {
                    nodeString = nodeList[i].tagName.toLocaleLowerCase() + ": " ;
                }

                if(nodeList[i].id !== ""){
                    nodeString +=  "id=" + nodeList[i].id + " ";
                }

                if(nodeList[i].className !== ""){
                    nodeString +=  "class=" + nodeList[i].className;
                }

                console.log(nodeString);
            }

            if(nodeList[i].hasChildNodes()){
                var indent;
                if(arguments[1] !== undefined){
                    indent = arguments[1] + "    ";
                }
                else {
                    indent = "    ";
                }

                printChildren(nodeList[i].childNodes, indent)
            }
        }
    }

    console.log(elements);
}
