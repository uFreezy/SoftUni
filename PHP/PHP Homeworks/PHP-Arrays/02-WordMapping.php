<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <style>
        table,tr,td {
            border: 2px solid gray;
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form method="post">
        <textarea name="input"></textarea>
        <input type="submit" name="submit" />
    </form>
</body>
</html>
<?php
    if(isset($_POST['submit']) && isset($_POST['input'])) {
        $strArr = preg_split('/\W/',$_POST['input']);
        $output = [];

        for($i = 0; $i < sizeof($strArr); $i++) {
            if(!preg_match('/\W/',$strArr[$i]) && $strArr[$i] != '') {
                $strArr[$i] = strtolower($strArr[$i]);
                if(isset($output[$strArr[$i]])) {
                    $output[$strArr[$i]]++;
                }
                else {
                    $output[$strArr[$i]] = 1;
                }
            }
        }
        echo '<table>';
        $keys = array_keys($output);

        for($i = 0; $i < sizeof($output); $i++) {
            echo '<tr>';
            echo '<td>' . $keys[$i] . '</td>';
            echo '<td>' . $output[$keys[$i]] . '</td>';
            echo '</tr>';
        }
        echo '</table>';

    }
?>
