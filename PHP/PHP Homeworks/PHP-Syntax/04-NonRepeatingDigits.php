<?php
    $input = 1000;
    $isNo = true;

    for($i = $input; $i >= 102; $i--) {
        $check = strval($i);
        if($check[0] != $check[1] && $check[0] != $check[2] && $check[1] != $check[2]) {
            echo $i . " ";
            $isNo = false;
        }
    }
    if($isNo) {
        echo "no";
    }
?>