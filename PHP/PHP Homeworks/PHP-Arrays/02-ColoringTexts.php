<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
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
        $input = $_POST['input'];

        for($i = 0; $i < strlen($input); $i++) {
            if(ord($input[$i]) % 2 != 0) {
                echo '<span style="color: blue">' . $input[$i] . ' </span>';
            }
            else {
                echo '<span style="color: red">' . $input[$i] . ' </span>';
            }
        }

    }
?>