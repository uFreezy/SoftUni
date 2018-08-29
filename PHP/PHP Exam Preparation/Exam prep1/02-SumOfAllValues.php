<?php
    $splitKeys = preg_split("/([0-9])/",$_GET["keys"],0,PREG_SPLIT_NO_EMPTY);
    $text = $_GET["text"];
    $startKey = $splitKeys[0];
    $endKey = end($splitKeys);
    $values = [];
    $match = [];
    $regex = "/(" . $startKey . ")(.*?)(" . $endKey . ")/";
    $result = 0;
    $valuesFound = false;
    $keyMissing = false;

    if($startKey == "" || $endKey == "" || sizeof($splitKeys) == 1 || preg_match('/\W/',$startKey) || preg_match('/\W/',$endKey)) {
        echo "<p>A key is missing</p>";
        $keyMissing = true;
    }
    if(!$keyMissing) {
        while(strpos($text,$startKey) !== false && strpos($text,$endKey) !== false) {
            preg_match($regex, $text, $match );
            if($match[2] != "") {
                array_push($values,$match[2]);
            }
            if($startKey == $endKey) {
                $text = substr($text,strpos($text,$endKey) + strlen($endKey));
                $text = substr($text,strpos($text,$endKey) + strlen($endKey));
            }
            else {
                $text = substr($text,strpos($text,$endKey) + strlen($endKey));
            }
        }
        for($k = 0; $k < sizeof($values); $k++) {
            if(is_numeric($values[$k])) {
                $valuesFound = true;
                $result += (float)$values[$k];
            }
        }
        if(!$valuesFound) {
            echo "<p>The total value is: <em>nothing</em></p>";
        }
        else {
            echo "<p>The total value is: <em>" . $result . "</em></p>";

        }
    }
?>