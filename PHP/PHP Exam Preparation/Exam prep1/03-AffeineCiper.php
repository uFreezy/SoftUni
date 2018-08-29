<?php
    $input = json_decode($_GET["jsonTable"]);
    $keys = array();
    array_push($keys, $input[1][0], $input[1][1]);
    $maxLen = 0;
    $output = "<table border='1' cellpadding='5'>";
    $isEmpty = true;

    for($i = 0; $i < sizeof($input[0]); $i++) {
        if(strlen($input[0][$i]) > $maxLen) {
            $maxLen = strlen($input[0][$i]);
        }
    }
    for($i = 0; $i < sizeof($input[0]); $i++) {
        $output .= "<tr>";
        for($k = 0; $k < $maxLen; $k++) {
            if($k < strlen($input[0][$i])) {
                if(!preg_match("/\W/",$input[0][$i][$k])) {
                    $isEmpty = false;
                    $curLetterPos = ord(strtoupper($input[0][$i][$k])) - ord('A');
                    $result = ($keys[0] * $curLetterPos + $keys[1]) % 26;
                    $output .= "<td style='background:#CCC'>" . (chr($result + ord('A'))) . "</td>";
                }
                else {
                    $output .= "<td style='background:#CCC'>" . $input[0][$i][$k] . "</td>";
                }
            }
            else {
                $isEmpty = false;
                $output .= "<td></td>";
            }
        }
        if($isEmpty) {
           $output .= "<td></td>";
        }
        $output .= "</tr>";
    }
    $output .= "</table>";
    echo $output;
?>