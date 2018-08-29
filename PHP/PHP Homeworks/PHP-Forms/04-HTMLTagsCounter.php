<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>HTML Tags Counter</title>
</head>
<body>
<form method="get">
    <label for="tagfield">Enter HTML tags:</label>
    <input type="text" name="tagfield"/>
    <input type="submit" />
</form>
<?php
    session_start();
    $validHTML = array("a", "abbr", "acronym", "address", "area", "b", "base", "bdo", "big", "blockquote",
        "body", "br", "button", "caption", "cite", "code", "col", "colgroup", "dd", "del", "dfn", "div",
        "dl", "DOCTYPE", "dt", "em", "fieldset", "form", "h1,h2,h3,h4,h5,andh6", "head", "html", "hr",
        "i", "img", "input", "ins", "kbd", "label", "legend", "li", "link", "map", "meta", "noscript",
        "object", "ol", "optgroup", "option", "p", "param", "pre", "q", "samp", "script", "select",
        "small", "span", "strong", "style", "sub", "sup", "table", "tbody", "td", "textarea", "tfoot",
        "th", "thead", "title", "tr", "tt", "ul", "var");
    $input = explode(" ", $_GET["tagfield"]);
    if(!isset($_SESSION["score"])) {
        $_SESSION["score"] = 0;
    }
    $htmlFound = false;

    for($i = 0; $i < count($input); $i++) {
        for($k = 0; $k < count($validHTML); $k++) {
            if($input[$i] == $validHTML[$k]) {
                $htmlFound = true;
                $_SESSION["score"]++;
                break;
            }
        }
    }
    if($htmlFound) {
        echo "<h1> Valid HTML tag! </h1>";
        echo "<h1> Score: " . $_SESSION["score"] . "</h1>";
    }
    else {
        echo "<h1> Invalid HTML tag! </h1>";
        echo "<h1> Score: " . $_SESSION["score"] . "</h1>";
    }
?>
</body>
</html>