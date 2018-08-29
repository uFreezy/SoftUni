<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Print Tags</title>
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
$str = explode(", ",$_GET["input"]);

for($i = 0; $i < sizeof($str); $i++) {
    echo  $i . " : " . $str[$i] . "<br/>";
}
?>
</body>
</html>