<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Form data</title>
    <style>
        input, label, button { display: inline-block}
        input {
            margin-bottom: 5px;
        }
        form {
            width: 180px;
        }
    </style>
</head>
<body>
<form action="07-FormData.php" method="get">
    <input type="text" name="name"/>
    <input type="text" name="age"/>
    <label for="male"><input type="radio" id="male" name="gender"/> Male</label>
    <label for="female"><input type="radio" id="female" name="gender"/> Female</label>
    <input type="submit"/>
</form>
<?php
    echo "My name is " . $_GET["name"] . ". I am " . $_GET["age"] . " years old." . "I am " . $_GET["gender"]
?>
</body>
</html>