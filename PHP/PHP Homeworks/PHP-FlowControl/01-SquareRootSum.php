<?php
    $sum = 0;

    echo "<table style='border: 2px solid gray'>";
    echo "<tr >";
    echo "<td style='border: 2px solid gray'><b>Number</b></td>";
    echo "<td style='border: 2px solid gray'><b>Square</b></td>";
    echo "</tr>";
    for($i = 0; $i <= 100; $i++) {
        if($i % 2 == 0) {
            echo "<tr >";
            echo "<td style='border: 2px solid gray'>" . $i . "</td>";
            echo "<td style='border: 2px solid gray'>" . round(sqrt($i),2) . "</td>";
            echo "</tr>";
            $sum += round(sqrt($i),2);
        }
    }
    echo "<tr >";
    echo "<td style='border: 2px solid gray'><b>Total</b></td>";
    echo "<td style='border: 2px solid gray'>" . $sum . "</td>";
    echo "</tr>";
    echo "</table>";
?>