<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
</head>
<body>
<form method="post">
    <textarea name="text"></textarea>
    <input type="text" name="word" />
    <input type="submit" name="submit" />
</form>
</body>
</html>
<?php
    if(isset($_POST['text']) && isset($_POST['word']) && isset($_POST['submit'])) {
        $word =  ' '. $_POST['word'];
        $delimiters = '!?.';
        $sentenceArr = preg_split( '/([' . $delimiters . '])/m', $_POST['text'], -1 , PREG_SPLIT_DELIM_CAPTURE);

        for($i = 0; $i < sizeof($sentenceArr); $i++) {
            if(strpos($sentenceArr[$i],$word) && !preg_match('/\w/',$sentenceArr[$i][strpos($sentenceArr[$i],$word)+strlen($word)])) {
                if($i+1 < sizeof($sentenceArr)) {
                    echo $sentenceArr[$i] . $sentenceArr[$i+1] . "<br/>";
                }

            }
            $i++;
        }
        //var_dump($sentenceArr);
    }
?>