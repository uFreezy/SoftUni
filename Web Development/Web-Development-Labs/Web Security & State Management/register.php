<?php
require_once "index.php";

if(isset($_POST["username"], $_POST["pass"])){
    try{
        $user = $_POST["username"];
        $pass = $_POST["pass"];

        $app->register($user,$pass);
        header("Location: login.php");
    }
    catch(Exception $e) {
        echo $e->getMessage();
    }
}

loadTemplate("register");