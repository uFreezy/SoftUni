<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <style>
        table,tr,td,th {
            border: 2px solid gray;
            border-collapse: collapse;
        }
    </style>
</head>
<body>
<form method="post">
    <label for="input">Input string: </label>
    <input type="text" name="input" id="input"/>
    <input type="submit" name="submit" />
</form>
</body>
</html>
<?php
    if(isset($_POST['input']) && isset($_POST['input'])) {
        $strArr = explode(', ',$_POST['input']);

        echo '<table>';

        for($i = 0; $i < sizeof($strArr); $i++) {
            //$strExpl = explode('',$strArr[$i]);
            $sum = 0;

            echo '<tr>';

            for($k = 0; $k < strlen($strArr[$i]); $k++) {
                $sum += $strArr[$i][$k];
            }
            if(ctype_digit($strArr[$i])) {
                echo '<td>' . $strArr[$i] . '</td>';
                echo '<td>' . $sum . '</td>';
            }
            else {
                echo '<td>' . $strArr[$i] . '</td>';
                echo '<td>I cannot sum that</td>';
            }
        }
    }
?>