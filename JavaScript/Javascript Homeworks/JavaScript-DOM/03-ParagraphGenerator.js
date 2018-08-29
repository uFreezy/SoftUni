/**
 * Created by Freezyy on 3/30/2015.
 */
function createParagraph(id, str) {
    var node = document.createElement('P');
    var textnode = document.createTextNode(str);

    node.appendChild(textnode);
    document.getElementById(id).appendChild(node);
}
