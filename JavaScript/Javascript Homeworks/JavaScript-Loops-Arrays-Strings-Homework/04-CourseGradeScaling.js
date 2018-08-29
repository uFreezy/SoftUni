/**
 * Created by Freezyy on 3/17/2015.
 */
function slove (str) {


    for (var key in str) {
        if((str[key].score * 1.1) % 1 != 0 && ((str[key].score * 1.1) % 1).toFixed(1).toString().indexOf('.0') <= -1) {
            str[key].score = (str[key].score * 1.1).toFixed(1);
        }
        else {
            str[key].score *= 1.1.toFixed(0);
        }
        if(str[key].score < 100) {
            str.splice(key,1);
        }
        else {
            str[key].hasPassed = "true";
        }
    }
    str.sort(function(a, b){
        var nameA=a.name.toLowerCase(),
            nameB=b.name.toLowerCase();
        if (nameA < nameB) {
            return -1;
        }
        if (nameA > nameB) {
            return 1;
        }
        return 0;
    });
    console.log(str);
}
slove([
        {
            'name' : 'Пешо',
            'score' : 91
        },
        {
            'name' : 'Лилия',
            'score' : 290
        },
        {
            'name' : 'Алекс',
            'score' : 343
        },
        {
            'name' : 'Габриела',
            'score' : 400
        },
        {
            'name' : 'Жичка',
            'score' : 70
        }
    ]
);