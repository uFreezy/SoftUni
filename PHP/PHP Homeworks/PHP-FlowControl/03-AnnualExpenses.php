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
    <label for="input">Enter number of years: </label>
    <input type="text" name="input"  id="input"/>
    <input type="submit" name="submit" />
</form>
</body>
</html>
<?php
    if(isset($_POST['submit']) && isset($_POST['input'])) {
        $years = $_POST['input'];
        $curYear = (int)date("Y");

        echo '<table>';
        echo '<tr>';
        echo '<th>Year</th>';
        echo '<th>January</th>';
        echo '<th>February</th>';
        echo '<th>March</th>';
        echo '<th>April</th>';
        echo '<th>May</th>';
        echo '<th>June</th>';
        echo '<th>July</th>';
        echo '<th>August</th>';
        echo '<th>September</th>';
        echo '<th>October</th>';
        echo '<th>November</th>';
        echo '<th>December</th>';
        echo '<th>Total:</th>';
        echo '</tr>';

        for($i = $curYear; $i > $curYear - $years; $i--) {
            $yearSum = 0;
            echo '<tr>';
            echo '<td>' . $i . '</td>';

            for($k = 0; $k < 12; $k++) {
                $rand = mt_rand(0,999);

                echo '<td>' . $rand . '</td>';
                $yearSum += $rand;
            }
            echo '<td>' . $yearSum . '</td>';
            echo '</td>';
        }
    }
?>