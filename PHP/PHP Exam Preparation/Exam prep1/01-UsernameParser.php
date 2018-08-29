<?php
    $names = preg_split('/[\r\n]+/', $_GET["list"], -1, PREG_SPLIT_NO_EMPTY);
    $output = "<ul>";

    for($i = 0; $i < sizeof($names); $i++) {
        if(strlen($names[$i]) < $_GET["length"]) {
            if(isset($_GET["show"])) {
                $output .= '<li style="color: red;">' . htmlspecialchars($names[$i]) . "</li>";
            }
    }
    else {
        $output .= "<li>" . htmlspecialchars($names[$i]) . "</li>";
    }
    }
    $output .= "</ul>";
    echo $output;
?>
