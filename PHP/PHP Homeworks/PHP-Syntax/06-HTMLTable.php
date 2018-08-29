<?php
    $name = "Gosho";
    $phone = "0899141432";
    $age = 99;
    $address = " Sample Address";

    echo "<table style='border: 2px solid black; border-collapse: collapse'>";
    echo "<tbody>";
    echo "<tr style='border: 2px solid black'>";
    echo "<td style='border: 2px solid black'> Name </td>";
    echo "<td> " . $name . " </td>" ;
    echo "</tr>";
    echo "<tr style='border: 2px solid black'>";
    echo "<td style='border: 2px solid black'> Phone Number </td>";
    echo "<td> " . $phone . " </td>" ;
    echo "</tr>";
    echo "<tr style='border: 2px solid black'>";
    echo "<td style='border: 2px solid black'> Age </td>";
    echo "<td> " . $age . " </td>" ;
    echo "</tr>";
    echo "<tr style='border: 2px solid black'>";
    echo "<td style='border: 2px solid black'> Address </td>";
    echo "<td> " . $address . " </td>" ;
    echo "</tr>";
    echo "</tbody>";
    echo "</table>";
?>