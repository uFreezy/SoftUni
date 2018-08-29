<?php
    session_start();
?>
<form method="post">
    <label for="number">Guess the random number (0-100)</label>
    <input type="text" name="number" />
    <input type="submit" name="submit"/>
</form>
<?php
    if(isset($_POST["submit"])){
        if(!is_numeric($_POST["number"]) || $_POST["number"] < 0 || $_POST["number"] > 100) {
            echo "Invalid number";
        } else {
            if($_POST["number"] > $_SESSION["number"]) {
                echo "Down!";
            } else if($_POST["number"] < $_SESSION["number"]){
                echo "Up!";
            } else {
                echo "Congratulations, " . $_SESSION["name"];
            }
        }
    }
?>
