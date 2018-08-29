/**
 * Created by ufree on 2/13/2016.
 */
var htmlGen = {
    createParagraph : function createParagraph(id, str) {
        var node = document.createElement('P');
        var textNode = document.createTextNode(str);

        node.appendChild(textNode);
        document.getElementById(id).appendChild(node);
    },
    createDiv : function createDiv(id, classHTML) {
        var node = document.createElement('DIV');

        node.className = classHTML;
        document.getElementById(id).appendChild(node);
    },
    createLink : function createLink(id, inner, link) {
        var node = document.createElement('A');
        var textNode = document.createTextNode(inner);

        node.href = link;
        node.appendChild(textNode);
        document.getElementById(id).appendChild(node);
    }
};