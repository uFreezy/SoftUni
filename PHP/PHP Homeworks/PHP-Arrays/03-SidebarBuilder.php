<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title></title>
    <style>
        .input > article {
            display: block;
            margin-top: 5px;
        }
        .sidebar > article {
            width: 200px;
            background: lightblue;
            border: 1px solid black;
            border-radius: 10px;
            padding-left: 10px;
            margin-top: 15px;
        }
        .sidebar > article > header {
            border-bottom: 1px solid black;
        }
        .sidebar > article > ul > li {
            text-decoration: underline;
        }
    </style>
</head>
<body>
<form method="post">
    <section class="input">
        <article>
            <label for="cat">Categories: </label>
            <input name="cat" id="cat" placeholder="Categories" />
        </article>
        <article>
            <label for="tags">Tags:</label>
            <input name="tags" id="tags" placeholder="tags" />
        </article>
        <article>
            <label for="months">Months: </label>
            <input name="months" id="months" placeholder="Months" />
        </article>
        <article>
            <input type="submit" name="submit" />
        </article>
    </section>
</form>
</body>
</html>
<?php
    if(isset($_POST['cat']) && isset($_POST['tags']) && isset($_POST['months']) && isset($_POST['submit'])) {
        function prtSidebar($title, $array) {
            echo '<article><header><h1>Categories</h1></header>';
            echo '<div>';
            arrIter($array);
            echo '</div>';
            echo '</article>';
        }
        function arrIter($array) {
            echo '<ul>';
            for($i = 0; $i < sizeof($array); $i++) {
                echo '<li>' . $array[$i] . '</li>';
            }
            echo '</ul>';
        }

        $cat =  preg_split('/, /', $_POST['cat']);
        $tags = preg_split('/, /', $_POST['tags']);
        $months = preg_split('/, /', $_POST['months']);

        echo '<section class="sidebar">';
        prtSidebar('Category',$cat);
        prtSidebar('Tags',$tags);
        prtSidebar('Months', $months);
        echo '</section>';




    }
?>