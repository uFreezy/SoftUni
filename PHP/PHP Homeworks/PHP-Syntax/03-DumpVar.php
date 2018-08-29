<?php
    $input = 5;

    if(gettype($input) == "integer" || gettype($input) == "double") {
        var_dump($input);
    }
    else {
        echo gettype($input);
    }
?>