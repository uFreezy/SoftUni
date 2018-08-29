<?php
require_once "index.php";

if(isset($_GET["id"])){
    $buildings = $app->createBuildings();
    $buildings->evolve($_GET['id']);
    header("Location: buildings.php");
    exit;

}

if(!$app->isLogged()){
    header("Location: login.php");
}

$buildings = $app->createBuildings();

loadTemplate('buildings', $buildings);