<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Most Frequent Tag</title>
</head>
<body>
<p>
    Enter tags:
</p>
<form method="get">
    <input type="text" name="input"/>
    <input type="submit"/>
</form>
<?php
if(isset($_GET["input"])) {
    $str = explode(", ",$_GET["input"]);
    $storeArr = [];

    for($i = 0; $i < sizeof($str); $i++) {
        if(isset($storeArr[$str[$i]])) {
            $storeArr[$str[$i]]++;
        }
        else {
            $storeArr[$str[$i]] = 1;
        }
    }
    uasort($storeArr, function($a,$b){
        return $b - $a;
    });
    $keyHolder = array_keys($storeArr);
    //sort($storeArr);

    for($i = 0; $i < count($keyHolder); $i++) {
        echo $keyHolder[$i] . " : " . $storeArr[$keyHolder[$i]] . " times" . "<br/>";
    }
    $keys = array_keys($storeArr);
    echo "<br/> <br/>" . "Most frequent tag is: " . $keys[0];
}
?>
</body>
</html>