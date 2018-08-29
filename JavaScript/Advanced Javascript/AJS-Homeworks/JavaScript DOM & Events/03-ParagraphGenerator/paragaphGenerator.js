/**
 * Created by ufree on 2/13/2016.
 */

function createParagraph(id, str) {
    var node = document.createElement('P');
    var textNode = document.createTextNode(str);

    node.appendChild(textNode);
    document.getElementById(id).appendChild(node);
}
