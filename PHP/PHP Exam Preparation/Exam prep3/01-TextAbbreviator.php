<?php
    $list = preg_split("/\n/",$_GET['list'], -1 , PREG_SPLIT_NO_EMPTY );
    $maxValue = $_GET['maxSize'];
    $newList = array();

    for($i = 0; $i < sizeof($list); $i++) {
        $list[$i] = trim($list[$i]);
        if($list[$i] !== '') {
            array_push($newList,$list[$i]);
        }
    }

    echo '<ul>';
    for($i = 0; $i < sizeof($newList); $i++) {
        if(strlen($newList[$i]) > $maxValue) {
            echo '<li>' . htmlspecialchars(substr($newList[$i],0,$maxValue)) . '...</li>';
        }
        else {
            echo '<li>' . htmlspecialchars($newList[$i]) . '</li>';
        }
    }
    echo '</ul>';
?>