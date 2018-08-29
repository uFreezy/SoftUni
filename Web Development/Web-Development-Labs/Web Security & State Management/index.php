<?php
session_start();

require_once "Core/App.php";

use Core\Db;
use Config\DbConfig;
use Core\App;

spl_autoload_register(function($class){
    $classPath = str_replace('\\','/',$class);
    require_once $classPath . '.php';
});

Db::SetInstance(
    DbConfig::DB_INSTANCE,
    DbConfig::DB_DRIVER,
    DbConfig::DB_USER,
    DbConfig::DB_PASS,
    DbConfig::DB_NAME,
    DbConfig::DB_HOST
);

$app = new App(
    Db::getInstance(DbConfig::DB_INSTANCE)
);

function loadTemplate($templateName, $data = null){
    require_once 'Templates/' . $templateName . '.php';
}