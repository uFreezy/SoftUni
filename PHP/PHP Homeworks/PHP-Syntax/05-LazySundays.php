<?php
    $day = 0;
    $date = $day . date("S") . date("F") . date("Y");

    while($day <= 31) {
        $dt = strtotime($date);

        if(date('l',$dt) == "Sunday") {
            echo date('jS F, Y',$dt) .  "</br>";
        }
        $day++;
        $date = $day . date("S") . date("F") . date("Y");
    }
?>