<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
    <form method="post">
        <input type="text" name="input" />
        <input type="submit" name="submit" />
    </form>
</body>
</html>
<?php
    if(isset($_POST['submit']) && isset($_POST['input'])) {
        $data = explode(", ",$_POST['input']);
        $randColor = mt_rand(1,5);
        $randCount = mt_rand(1,5);

        echo "<table>";
        echo "<tr>";
        echo "<th>Car</th>";
        echo "<th>Color</th>";
        echo "<th>Count</th>";
        echo "</tr>";
        for($i = 0; $i < sizeof($data); $i++) {
            echo "<tr>";
            echo "<td><b>" . $data[$i] . "</b></td>";
            switch($randColor) {
                case 1:
                    echo "<td>Gray</td>";
                    break;
                case 2:
                    echo "<td>Black</td>";
                    break;
                case 3:
                    echo "<td>White</td>";
                    break;
                case 4:
                    echo "<td>Blue</td>";
                    break;
                case 5:
                    echo "<td>Brown</td>";
                    break;
            }
            echo "<td>" . $randCount . "</td>";
            echo "</tr>";

            $randColor = mt_rand(1,5);
            $randCount = mt_rand(1,5);
        }
        echo "</table>";
    }
?>