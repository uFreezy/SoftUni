<form method="post">
    <input type="text" name="name" />
    <input type="submit" name="play" value="Start Game!" />
</form>

<?php
    if(isset($_POST["play"])){
        session_start();

        $_SESSION["name"] = $_POST["name"];
        $_SESSION["number"] = rand(0,100);

        header("Location: play.php"); /* Redirect browser */
        exit();
    }
?>