/**
 * Created by ufree on 2/28/2016.
 */

$.getJSON("input.json")
    .error(function () {
        console.log('Error in parsing JSON!');
    })
    .done(function (res) {
        BindData(res);
    });



function BindData(data){
    var table = $('<table></table>');
    var keys = Object.keys(data[0]);

    var thead = $('<thead></thead>');
    keys.forEach(function (key) {
        var td = $('<td></td>');
        td.text(key);
        thead.append(td);
    });

    table.append(thead);

    var tbody = $('<tbody></tbody>');
    data.forEach(function (item) {
        var tr = $('<tr></tr>');

        for(var prop in item){
            var td = $('<td></td>');
            td.text(item[prop]);
            tr.append(td);
        }

        tbody.append(tr);
    });

    table.append(tbody);

    $('#wrapper').append(table);
}