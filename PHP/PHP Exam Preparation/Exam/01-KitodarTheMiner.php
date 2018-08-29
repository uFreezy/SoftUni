<?php
    $input = explode(', ', $_GET['data']);
    $validData = array();
    $minerals = array(0,0,0);


    for($i = 0; $i < sizeof($input); $i++) {
        if(preg_match("/((\s+)?mine\s+\w+\s+(gold|silver|diamonds)\s+\d+)/",strtolower($input[$i]))) {
            preg_match("/(gold|silver|diamonds)[\s+](\d+)/",strtolower($input[$i]),$mineral);
            //var_dump($mineral);
            if($mineral[1] == 'gold') {
                $minerals[0]+= intval($mineral[2]);
            }
            else if($mineral[1] == 'silver') {
                $minerals[1]+= intval($mineral[2]);
            }
            else {
                $minerals[2]+= intval($mineral[2]);
            }
        }
    }
    echo '<p>*Gold: '. $minerals[0] .'</p>';
    echo '<p>*Silver: '. $minerals[1] .'</p>';
    echo '<p>*Diamonds: '. $minerals[2] .'</p>';

?>