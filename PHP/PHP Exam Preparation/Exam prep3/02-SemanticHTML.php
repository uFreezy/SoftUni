<?php
    $regex = "/(<div+)(.+)?(id\=\"|class=\")(\w+\")(.+>|>)/";

    $html = $_GET['html'];

    preg_match_all($regex,$html,$result);
    var_dump($result);
?>