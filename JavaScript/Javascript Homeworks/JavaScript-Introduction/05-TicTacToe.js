/**
 * Created by Freezyy on 3/11/2015.
 */

var turn = 1,
    checkIfSomebodyWon = false,
    List = document.getElementsByTagName("button");

function myFunction(number) {
    if(!checkIfSomebodyWon && turn <= 9) {
        if(turn % 2 !== 0 && List[number].innerHTML === "") {
            List[number].style.fontSize = "200%";
            List[number].innerHTML = "X";
            turn++;
        }
        else if (turn % 2 === 0 && List[number].innerHTML === ""){
            List[number].style.fontSize = "200%";
            List[number].style.color = "#00FF00";
            List[number].innerHTML = "O";
            turn++;
        }
        if(CheckForWinner(List)) {
            checkIfSomebodyWon = true;
            alert("Player " + List[number].innerHTML + " won!");
        }
        if(turn > 9) {
            alert("No winner! Please refresh the page to play another game");
        }
    }
}
function CheckForWinner(List) {
    var value = false;

    if(List[0].innerHTML === List[1].innerHTML && List[0].innerHTML === List[2].innerHTML && List[0].innerHTML !== "") {
        value = true;
        return value;
    }
    else if(List[3].innerHTML === List[4].innerHTML && List[3].innerHTML === List[5].innerHTML && List[3].innerHTML !== "") {
        value = true;
        return value;
    }
    else if(List[6].innerHTML === List[7].innerHTML && List[6].innerHTML === List[8].innerHTML && List[6].innerHTML !== "") {
        value = true;
        return value;
    }
    else if(List[0].innerHTML === List[3].innerHTML && List[0].innerHTML === List[6].innerHTML && List[0].innerHTML !== "") {
        value = true;
        return value;
    }
    else if(List[1].innerHTML === List[4].innerHTML && List[1].innerHTML === List[7].innerHTML && List[1].innerHTML !== "") {
        value = true;
        return value;
    }
    else if(List[2].innerHTML === List[5].innerHTML && List[2].innerHTML === List[8].innerHTML && List[2].innerHTML !== "") {
        value = true;
        return value;
    }
    else if(List[0].innerHTML === List[4].innerHTML && List[0].innerHTML === List[8].innerHTML && List[0].innerHTML !== "") {
        value = true;
        return value;
    }
    else if(List[2].innerHTML === List[4].innerHTML && List[2].innerHTML === List[6].innerHTML && List[2].innerHTML !== "") {
        value = true;
        return value;
    }
    return value;
}
function Reset() {
    turn = 1;
    checkIfSomebodyWon = false;

    for(var i = 0; i < List.length; i++) {
        List[i].innerHTML = "";
        List[i].style.color = "black";
    }
}