<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>

</head>
<body>
<form method="post">
    <input type="text" name="input" id="input"/>
    <label for="palindrome">Check palindrome</label>
    <input type="radio" name="action" id="palindrome" value="palindrome"/>
    <label for="reverse">Reverse string</label>
    <input type="radio" name="action" id="reverse" value="reverse"/>
    <label for="split">Split</label>
    <input type="radio" name="action" id="split" value="split"/>
    <label for="hash">Hash string</label>
    <input type="radio" name="action" id="hash" value="hash"/>
    <label for="shuffle">Shuffle string</label>
    <input type="radio" name="action"  id="shuffle" value="shuffle"/>
    <input type="submit" name="submit" />
</form>
</body>
</html>
<?php
    if(isset($_POST['submit']) && isset($_POST['input']) && isset($_POST['action'])) {
        switch($_POST['action']) {
            case 'palindrome':
                if($_POST['input'] == strrev($_POST['input'])) {
                    echo $_POST['input'] . " is palindrome!";
                }
                else {
                    echo $_POST['input'] . " is not palindrome!";
                }
                break;
            case 'reverse':
                echo strrev($_POST['input']);
                break;
            case 'split':
                $charArray = str_split($_POST['input']);

                for($i = 0; $i < sizeof($charArray); $i++) {
                    if($charArray[$i] != " ") {
                        echo $charArray[$i] . ' ';
                    }
                }
                break;
            case 'hash':
                echo @crypt($_POST['input']);
                break;
            case 'shuffle':
                str_shuffle($_POST['input'],'MD5');
                break;
            default:
        }
    }
?>