<?php
require_once "index.php";

if(!$app->isLogged()){
    header("Location: login.php");
}

loadTemplate("profile", $app->getUser());

require_once "editProfile.php";
?>

<div>
    Go to:
    <a href="buildings.php">Buildings</a>
</div>
