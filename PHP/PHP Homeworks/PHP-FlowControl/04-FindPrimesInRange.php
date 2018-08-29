<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<form method="post">
    <label for="start">Starting index: </label>
    <input type="text" name="start" id="start" />
    <label for="end">End: </label>
    <input type="text" name="end" id="end" />
    <input type="submit" name="submit" />
</form>
</body>
</html>
<?php
function isPrime($num) {
    //1 is not prime.
    if($num == 1)
        return false;

    //2 is prime (the only even number that is prime)
    if($num == 2)
        return true;

    /**
     * if the number is divisible by two, then it's not prime and it's no longer
     * needed to check other even numbers
     */
    if($num % 2 == 0) {
        return false;
    }

    /**
     * Checks the odd numbers. If any of them is a factor, then it returns false.
     * The sqrt can be an aproximation, hence just for the sake of
     * security, one rounds it to the next highest integer value.
     */
    for($i = 3; $i <= ceil(sqrt($num)); $i = $i + 2) {
        if($num % $i == 0)
            return false;
    }

    return true;
}
    if(isset($_POST['start']) && isset($_POST['end']) && isset($_POST['submit'])) {


        for($i = $_POST['start']; $i < $_POST['end']; $i++) {
            if(isPrime($i)) {
                if($i == $_POST['end'] - 1) {
                    echo '<b>' . $i . '</b> ';
                }
                else {
                    echo '<b>' . $i . '</b>, ';
                }
            }
            else {
                if($i == $_POST['end'] - 1) {
                    echo $i;
                }
                else {
                    echo $i . ', ';
                }

            }
        }
    }
?>