
<?php
$infoHolder = array();
$infoHolder['variables'] = array();
$infoHolder['loops'] = array('while'=>array(),'for'=>array(),'foreach'=>array());
$infoHolder['conditionals'] = array();
//var_dump(json_encode($infoHolder));

$data = $_GET['code'];
$data = str_replace("\n", "", $data);
$data = str_replace("\r", "", $data);
//var_dump($data)
preg_match_all('/(\$[_\d+]?(\w+))/',$data,$varArr);
foreach($varArr[0] as $var) {
    if(isset($infoHolder['variables'][$var])) {
        $infoHolder['variables'][$var]++;
    }
    else {
        $infoHolder['variables'][$var] = 1;
    }
}
preg_match_all('/(while(\s+)?\(.+\)(\s+)?{(.*)})/s',$data,$whileArr);
//var_dump($whileArr[0]);
foreach($whileArr[0] as $while) {
    $whileData = explode('{',$while);
    $whileData[0] = trim($whileData[0]);
    array_push($infoHolder['loops']['while'],$whileData[0]);
}
preg_match_all('/(for(\s+)?\(.+\)(\s+)?{(.*)})/s',$data,$forArr);
foreach($forArr[0] as $for) {
    $forData = explode('{',$for);
    $forData[0] = trim($forData[0]);
    array_push($infoHolder['loops']['for'],$forData[0]);
}
preg_match_all('/(for(\s+)each(\s+)?\(.+\)(\s+)?{(.*)})/s',$data,$forEachArr);
foreach($forEachArr[0] as $forEach) {
    $forEachData = explode('{',$forEach);
    $forEachData[0] = trim($forEachData[0]);
    array_push($infoHolder['loops']['foreach'],$forEachData[0]);
}
preg_match_all('/((if|else\s+if)(\s+)?\(.+\)(\s+)?{(.*)})/s',$data,$conArr);
foreach($conArr[0] as $con) {
    $conData = explode('{',$con);
    $conData[0] = trim($conData[0]);
    array_push($infoHolder['conditionals'],$conData[0]);
}
echo json_encode($infoHolder);

?>