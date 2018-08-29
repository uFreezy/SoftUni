<?php
    $strArr = array();
    $arrowSum = array(0,0,0);

    for($i = 0; $i < 4; $i++) {
        if($i == 0) {
            if(preg_match("/(>>>----->>)|(>>----->)|(>----->)/",$_GET['arrows'])) {
                //array_push($strArr, $_GET['arrows']);
                $arrowSum[2] += preg_match_all("/>>>----->>/",$_GET['arrows']);
                $arrowSum[1] += preg_match_all("/>>----->/",$_GET['arrows']);
                $arrowSum[0] += preg_match_all("/>----->/",$_GET['arrows']);
            }
        }
        else {
            if(preg_match("/(>>>----->>)|(>>----->)|(>----->)/",$_GET['arrows'. $i])) {
                //array_push($strArr, $_GET['arrows'. $i]);
                $arrowSum[2] += preg_match_all("/>>>----->>/",$_GET['arrows' .$i]);
                $arrowSum[1] += preg_match_all("/>>----->/",$_GET['arrows' . $i]);
                $arrowSum[0] += preg_match_all("/>----->/",$_GET['arrows' . $i]);
            }
        }

    }
    $arrowSum[0] -= $arrowSum[1];
    $arrowSum[1] -= $arrowSum[2];
    var_dump(intval($arrowSum[0] . $arrowSum[1] . $arrowSum[2]));
    $sumToBinary = decbin(intval($arrowSum[0] . $arrowSum[1] . $arrowSum[2]));
    $reversedToBinary = strrev($sumToBinary);
    $output = bindec($sumToBinary . $reversedToBinary);
    //var_dump($output);
    echo $output;
?>