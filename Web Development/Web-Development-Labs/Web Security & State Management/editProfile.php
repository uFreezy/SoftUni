<?php
require_once "index.php";

if(isset($_POST["edit"])){
    if($_POST["password"] != $_POST["repeat"] || empty($_POST["password"])){
        header("Location: profile.php?error=1");
        exit;
    }

    $user = new \Core\User(
        $_SESSION['user_id'],
        $_POST['username'],
        $_POST['password']
    );

    if($app->editUser($user)){
        header("Location: profile.php?success=1");
        exit;
    }

    header("Location: profile.php?error=1");
    exit;
}
loadTemplate("editProfile", $app->getUser());