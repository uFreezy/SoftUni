<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<form method="post">
    <textarea name="text"></textarea>
    <input type="text" name="input" />
    <input type="submit" name="submit" />
</form>
</body>
</html>
<?php
    if(isset($_POST['input']) && isset($_POST['submit'])) {
        $bannedWords = preg_split('/, /', $_POST['input']);
        $input = $_POST['text'];

        for($i = 0; $i < sizeof($bannedWords); $i++) {
            $replStr = '';
            for($k = 0; $k < strlen($bannedWords[$i]); $k++) {
                $replStr .= "*";
            }
            $input = str_replace($bannedWords[$i],$replStr,$input);
        }
        echo $input;
    }
?>