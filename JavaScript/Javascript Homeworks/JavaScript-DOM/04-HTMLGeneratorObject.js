/**
 * Created by Freezyy on 3/30/2015.
 */
var HTMLGen = {
    createParagraph : function createParagraph(id, str) {
        var node = document.createElement('P');
        var textnode = document.createTextNode(str);

        node.appendChild(textnode);
        document.getElementById(id).appendChild(node);
    },
    createDiv : function createDiv(id, classHTML) {
        var node = document.createElement('DIV');

        node.className = classHTML;
        document.getElementById(id).appendChild(node);
    },
    createLink : function createLink(id, inner, link) {
        var node = document.createElement('A');
        var textnode = document.createTextNode(inner);

        node.href = link;
        node.appendChild(textnode);
        document.getElementById(id).appendChild(node);
    }
};