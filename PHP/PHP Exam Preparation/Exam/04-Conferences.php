<?php
    $regex = "(\[((\d{4}-\d{2}-\d{2},)|(\d{4}\/\d{2}\/\d{2},))\s+(#[\w\.\-]+,)\s+('.+',)\s+([\w\,\-]+,)\s+(\d+,)\s+(\d+)])";
    preg_match_all('/'. $regex .'/',$_GET['conferences'],$input);
    $validMatches = array();

    foreach($input[0] as $inp) {
        //echo $inp . "<br/>";
        array_push($validMatches,$inp);
    }
    usort($validMatches,function($a,$b){
        $splitA = preg_split('/,/',$a);
        $splitB = preg_split('/,/',$b);
        $dateA = substr($splitA[0],1);
        $dateB = substr($splitB[0],1);
        $dateA = str_replace('-','/',$dateA);
        $dateB = str_replace('-','/',$dateB);

        //var_dump($dateA);
        //var_dump($dateB);
        $format = 'Y/m/d';
        $zone = new DateTimeZone('UTC');
        $d1 = DateTime::createFromFormat($format, $dateA, $zone)->format('U');
        $d2 = DateTime::createFromFormat($format, $dateB, $zone)->format('U');
        if($d1 < $d2) {
            return 1;
        }
        else if($d1 == $d2) {
            if($splitA[sizeof($splitA)- 3] < $splitB[sizeof($splitB)- 3]) {
                return 1;
            }
            else if($splitA[sizeof($splitA)- 3] == $splitB[sizeof($splitB)- 3]) {
                if($splitA[sizeof($splitA)- 2] - $splitA[sizeof($splitA)- 1] < $splitB[sizeof($splitB)- 2] - $splitB[sizeof($splitB)- 1]) {
                    return 1;
                }
                else if($splitA[sizeof($splitA)- 2] - $splitA[sizeof($splitA)- 1] == $splitB[sizeof($splitB)- 2] - $splitB[sizeof($splitB)- 1]) {
                    if($splitA[2] < $splitB[2]) {
                        return 1;
                    }
                    else {
                        return -1;
                    }
                }
                else {
                    return -1;
                }
            }
            else {
                return -1;
            }
        }
        else {
            return -1;
        }
    });

    $maxDisplayVal = $_GET['page'] * $_GET['pageSize'];
    $minDisplayVal = ($maxDisplayVal - $_GET['pageSize'])+1;
    echo '<table border="1" cellpadding="5">';
    echo '<tbody>';
    echo '<tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>';
    for($i = 0; $i< sizeof($validMatches);$i++) {
        echo '<tr>';
        $dates = array();
        $split = preg_split('/,/',$validMatches[$i]);
        foreach($validMatches as $match2) {
            $splitA = preg_split('/,/',$match2);
            $splitB = preg_split('/,/',$match2);
            array_push($dates,preg_replace('/\W+/','',substr($splitA[0],1)));
            array_push($dates,preg_replace('/\W+/','',substr($splitB[0],1)));
        }
        $dateOcc = preg_match_all('/'.$dates[$i].'/',$validMatches[$i]);

        var_dump($dateOcc);
        echo '<td rowspan="'. $dateOcc .'">random date</td>';
        echo '<td>'. $split[2] .'</td>';
        echo '<td>'. $split[1] .'</td>';
        echo '<td>0</td>';
        echo '<td>'.(intval($split[4]) - intval($split[5])).'</td>';
        echo '</tr>';
    }
    echo '</tbody>';
    echo '</table>';
    //var_dump($validMatches);
?>