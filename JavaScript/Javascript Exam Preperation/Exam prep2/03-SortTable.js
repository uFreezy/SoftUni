/**
* Created by Freezyy on 3/24/2015.
*/
function SortTable(arr) {
    arr.shift();
    arr.shift();
    arr.pop();
    arr.sort(function(a,b) {
        var value1 = a.substring(SecondIndexOf('<td>',a)+4, a.substring(SecondIndexOf('<td>',a)+4).indexOf('<'));
        var value2 = b.substring(SecondIndexOf('<td>',b)+4, b.substring(SecondIndexOf('<td>',b)+4).indexOf('<'));

        if(parseFloat(value1) > parseFloat(value2)) return 1;
        else if (parseFloat(value1) == parseFloat(value2)) {
            if(a.substring(a.indexOf('<td>')+4) > b.substring(b.indexOf('<td>')+4)) return 1;
            else return -1;
        }
        else return -1;
    });
    console.log('<table>');
    console.log('<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');
    for(var index in arr) {
        console.log(arr[index]);
    }
    console.log('</table>');

    function SecondIndexOf(Val, Str)
    {
        var Fst = Str.indexOf(Val);
        var Snd = Str.indexOf(Val, Fst+1);
        return Snd
    }
}

var arr = [
    '<table>',
    '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
    '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
    '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
    '<tr><td>Laptop Lenovo IdeaPad B5400</td><td>929.00</td><td>0</td></tr>',
    '<tr><td>Laptop ASUS ROG G550JK-CN268D</td><td>1939.00</td><td>+1</td></tr>',
    '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
    '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
    '<tr><td>Kamenitza Lemon 1 l</td><td>1.65</td><td>+7</td></tr>',
    '<tr><td>Vodka Absolute 1 l</td><td>22.00</td><td>+2</td></tr>',
    '<tr><td>Laptop Dell Inspiron 3537</td><td>1199.0</td><td>+3</td></tr>',
    '<tr><td>Laptop HP 250 G2</td><td>629</td><td>-10</td></tr>',
    '<tr><td>Ariana Radler 1.5 l</td><td>2.79</td><td>+33</td></tr>',
    '<tr><td>Coffee Lavazza 250 gr.</td><td>8.73</td><td>+10</td></tr>',
    '<tr><td>Coffee Cup 0.250</td><td>0.02</td><td>0</td></tr>',
    '<tr><td>Car BMW i8</td><td>203500</td><td>+7</td></tr>',
    '<tr><td>Vitamin B5, 350 mg</td><td>16.50</td><td>+3</td></tr>',
    '<tr><td>Book "Eloquent JavaScript" by M. Haverbeke</td><td>0</td><td>+653</td></tr>',
    '<tr><td>Apple iPad mini 16GB MD528HC/A</td><td>529.90</td><td>+5</td></tr>',
    '<tr><td>HP ElitePad 1000 G2</td><td>2369.00</td><td>0</td></tr>',
    '</table>'
];

SortTable(arr);