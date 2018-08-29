<?php
require_once "index.php";

if($app->isLogged()){
    header("Location: profile.php");
}

if (isset( $_POST["username"], $_POST["pass"])) {
    try {
        $user = $_POST["username"];
        $pass = $_POST["pass"];
        $app->login($user,$pass);

        header("Location: profile.php");
    } catch (Exception $e) {
        echo $e->getMessage();
    }
}

loadTemplate("login");