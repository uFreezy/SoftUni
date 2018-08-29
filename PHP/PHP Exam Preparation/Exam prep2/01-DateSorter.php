<?php
    date_default_timezone_set('Europe/Sofia');
    $dates = preg_split('/\n/', $_GET['list']);
    $curDate = new DateTime(trim($_GET['currDate']));
    $newDates = array();

    $dates = array_map('trim', $dates);
    $dates = array_filter($dates);
    $dates = array_values($dates);

    for($i = 0; $i < sizeof($dates); $i++) {
        $dates[$i] = date_create($dates[$i]);
        @$dates[$i] = date_format($dates[$i], 'd/m/Y');

        if(preg_match('/(\d+)(\/)(\d+)(\/)(\d+)/',$dates[$i])) {
            array_push($newDates,$dates[$i]);
        }
    }
    usort($newDates,'sortDates');

    echo '<ul>';
    foreach($newDates as $date) {
        $isBigger = isBigger($date,$curDate->format("d/m/Y"));

        if($isBigger < 0) {
            echo '<li><em>' . $date . '</em></li>';
        }
        else {
            echo '<li>' . $date . '</li>';
        }
    }
    echo '</ul>';

    function sortDates($a, $b){
        $format = 'd/m/Y';
        $zone = new DateTimeZone('UTC');
        $d1 = DateTime::createFromFormat($format, $a, $zone)->format('U');
        $d2 = DateTime::createFromFormat($format, $b, $zone)->format('U');
        if($d1 < $d2) {
            return -1;
        }
        else if($d1 == $d2) {
            return 0;
        }
        else {
            return 1;
        }
    };
    function isBigger($date, $curDate) {
        $format = 'd/m/Y';
        $zone = new DateTimeZone('UTC');
        $d1 = DateTime::createFromFormat($format, $date, $zone)->format('U');
        $d2 = DateTime::createFromFormat($format, $curDate, $zone)->format('U');
        if($d1 < $d2) {
            return -1;
        }
        else if($d1 == $d2) {
            return 0;
        }
        else {
            return 1;
        }
    };
?>