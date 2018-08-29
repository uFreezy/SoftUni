<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <style>
        section{
            height:auto;
            width:auto;
            border:1px solid gray;
            padding: 0 0 20px 20px;
            margin-bottom: 20px;
        }
        span{
            display: block;
            width: 135px;
            margin-top:-10px;
            margin-left:5px;
            background:white;
        }
        input, label, #buttonholder {
            display: block;
        }
        .speceles {
            display: inline-block;
        }
        .innerLanguageDiv {
            display: block;
        }
        #languageDiv > .innerLanguageDiv > input {
            display: inline-block;
        }
        #span2 { width: 130px;}
        #span3 { width: 110px;}
        #span4 { width: 80px}
        table {
            margin-top: 50px;
        }
        table, tr, td, th {
            border: 3px solid gray;
            border-collapse: collapse;
        }
        .innerTable {
            margin-top: 0;
        }
    </style>
    <script>

        function removeEle(str) {
            document.getElementById(str).innerHTML = document.getElementById(str).innerHTML.substr(0,
                document.getElementById(str).innerHTML.lastIndexOf("<div"));
            if(str == "languageDiv") {
                var val = parseInt(document.getElementById("languageCount").getAttribute("value"));
                if(val -1 >= 1) {
                    document.getElementById("languageCount").setAttribute("value",val-1) ;
                }

            }
            else {
                val =  parseInt(document.getElementById("lanCount").getAttribute("value"));
                if(val -1 >= 1) {
                    document.getElementById("lanCount").setAttribute("value",val-1) ;
                }
            }
        }
        function addEle(str) {
            if(str == "languageDiv") {
                var val = parseInt(document.getElementById("languageCount").getAttribute("value"));
                val++;
                document.getElementById("languageCount").setAttribute("value",val) ;

                document.getElementById(str).innerHTML += '<div class="innerLanguageDiv"> ' +
                '<input type="text" name="language' + val +'" id="language"/>' +
                '<select name="languageLvl'+ val +'">' +
                '<option>Beginner</option>' +
                '<option>Programmer</option>' +
                '<option>Ninja</option>' +
                '</select> </div>';
            }
            else {
                val =  parseInt(document.getElementById("lanCount").getAttribute("value"));
                val++;
                document.getElementById("lanCount").setAttribute("value",val) ;

                document.getElementById(str).innerHTML += '<div class="innerLanDiv"> ' +
                '<input type="text" class="speceles" id="lan" name="lan'+ val +'" /> ' +
                '<select name="lanComp' + val + '"> ' +
                '<option disabled selected>-Comprehension-</option> ' +
                '<option>beginner</option> ' +
                '<option>advanced</option> ' +
                '<option>intermediate</option> ' +
                '</select> ' +
                '<select name="lanRead' + val + '"> ' +
                '<option disabled selected>-Reading-</option> ' +
                '<option>beginner</option> ' +
                '<option>advanced</option> ' +
                '<option>intermediate</option> ' +
                '</select> ' +
                '<select name="lanWrite' + val + '"> ' +
                '<option disabled selected>-Writing-</option> ' +
                '<option>beginner</option> ' +
                '<option>advanced</option> ' +
                '<option>intermediate</option> ' +
                '</select> ' +
                '</div>';
            }

        }
    </script>
</head>
<body>
<form method="get">
    <section>
        <span>Personal information</span>
        <input type="text" placeholder="First name" name="name"/>
        <input type="text" placeholder="Last name" name="lastname"/>
        <input type="text" placeholder="Email" name="email"/>
        <input type="text" placeholder="Phone number" name="number"/>
        <label for="male" class="speceles">Male</label>
        <input type="radio" name="male" id="male" class="speceles"/>
        <label for="female" class="speceles">Female</label>
        <input type="radio" name="female"  id="female" class="speceles"/>
        <label for="date">Birthdate</label>
        <input type="date" name="date" id="date"/>
        <label for="nationality">Nationality</label>
        <select name="nationality">
            <option value="Country1">Sample country1</option>
            <option value="Country2">Sample country2</option>
            <option value="Country3">Sample country3</option>
            <option value="Country4">Sample country4</option>
            <option value="Country5">Sample country5</option>
        </select>
    </section>
    <section>
        <span id="span2">Last Work Position</span>
        <label for="workpos">Company Name</label>
        <input type="text"  id="workpos" name="workpos"/>
        <label for="fromdate">From</label>
        <input type="date" id="fromdate" name="fromdate"/>
        <label for="todate">To</label>
        <input type="date" id="todate" name="todate"/>
    </section>
    <section>
        <span id="span3">Computer Skills</span>
        <label for="language">Programming languages</label>
        <div id="languageDiv">
            <input type="hidden" value="1" name="languageCount"  id="languageCount"/>
            <div class="innerLanguageDiv">
                <input type="text" name="language1" id="language"/>
                <select name="languageLvl1">
                    <option>Beginner</option>
                    <option>Programmer</option>
                    <option>Ninja</option>
                </select>
            </div>

        </div>
        <button onclick="removeEle('languageDiv')" type="button">Remove language</button>
        <button onclick="addEle('languageDiv')" type="button">Add language</button>
    </section>
    <section>
        <span id="span4">Other skills</span>
        <label for="lan">Languages</label>
        <div id="lanDiv">
            <input type="hidden" value="1" name="lanCount" id="lanCount"/>
            <div class="innerLanDiv">
                <input type="text" class="speceles" id="lan" name="lan1" />
                <select name="lanComp1">
                    <option disabled selected>-Comprehension-</option>
                    <option>beginner</option>
                    <option>advanced</option>
                    <option>intermediate</option>
                </select>
                <select name="lanRead1">
                    <option disabled selected>-Reading-</option>
                    <option>beginner</option>
                    <option>advanced</option>
                    <option>intermediate</option>
                </select>
                <select name="lanWrite1">
                    <option disabled selected>-Writing-</option>
                    <option>beginner</option>
                    <option>advanced</option>
                    <option>intermediate</option>
                </select>
            </div>
        </div>
        <div id="buttonholder">
            <button onclick="removeEle('lanDiv')" type="button">Remove language</button>
            <button onclick="addEle('lanDiv')" type="button">Add language</button>
        </div>
        <label>Driver's license</label>
        <label class="speceles">B</label>
        <input type="checkbox" name="licenseB" id="licenseB" class="speceles"/>
        <label class="speceles">A</label>
        <input type="checkbox" name="licenseA" id="licenseA" class="speceles"/>
        <label class="speceles">C</label>
        <input type="checkbox" name="licenseC" id="licenseC" class="speceles"/>
    </section>
    <input type="submit" name="submit"/>
</form>
<?php
    if(isset($_GET["submit"])) {
        $firstName = $_GET["name"];
        $lastName = $_GET["lastname"];
        $email = $_GET["email"];
        $phone = $_GET["number"];
        $gender = "";
        $birthdate = $_GET["date"];
        $nationality = $_GET["nationality"];

        if (strlen($firstName) < 2 || strlen($firstName) > 20) {
            exit("Your first name must be between 2 and 20 symbols!");
        }
        if (strlen($lastName) < 2 || strlen($lastName) > 20) {
            exit("Your last name must be between 2 and 20 symbols!");
        }
        if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
            exit("Invalid email.");
        }
        if (preg_match("/([A-Z]|[a-z])\w+/", $phone) != false) {
            exit("Invalid phone.");
        }
        if ($_GET["male"] != "on" && $_GET["female"] != "on") {
            exit("You must set a gender.");
        } else {
            if ($_GET["male"] == "on") {
                $gender = "male";
            } else {
                $gender = "female";
            }
        }


        $output = "<table><tr><th colspan='2'>Personal Information</th></tr>
                          <tr><td>First name</td><td>" . $firstName . "</td></tr>
                          <tr><td>Last name</td><td>" . $lastName . "</td></tr>
                          <tr><td>Email</td><td>" . $email . "</td></tr>
                          <tr><td>Phone</td><td>" . $phone . "</td></tr>
                          <tr><td>Gender</td><td>" . $gender . "</td></tr>
                          <tr><td>Birth Date</td><td>" . $birthdate . "</td></tr>
                          <tr><td>Nationality</td><td>" . $nationality . "</td></tr></table>
                   <table><tr><th colspan='2'>Last Work Position</th></tr>
                           <tr><td>Company Name</td><td>" . $_GET["workpos"] . "</td></tr>
                           <tr><td>From</td><td>" . $_GET["fromdate"] . "</td></tr>
                           <tr><td>To</td><td>" . $_GET["todate"] . "</td></tr></table>
                   <table><tr><th colspan='2'>Computer Skills</th></tr>
                           <tr><td>Programming languages</td><td> <table class='innerTable'>
                           <tr><th>Language</th><th>Skill level</th></tr>";

        if(isset($_GET["languageCount"])) {
            for($i = 1; $i <= $_GET["languageCount"]; $i++) {
                $getLanguage = "language" . $i;
                $getLevel = "languageLvl" . $i;

                $output .= "<tr><td>".$_GET[$getLanguage]."</td><td>".$_GET[$getLevel]."</td></tr>";
            }
            $output .= "</table></td></tr></table>";
        }

        $output .= "<table><tr><th colspan='2'>Other Skills</th></tr>
                    <tr><td>Languages</td><td>
                        <table class='innerTable'><tr><th>Language</th><th>Comprehension</th><th>Reading</th><th>Writing</th></tr>";
        if(isset($_GET["lanCount"])) {
            for($i = 1; $i <= $_GET["lanCount"]; $i++) {
                $getLanguage = "lan" . $i;
                $lanComp = "lanComp" . $i;
                $lanRead = "lanRead" . $i;
                $lanWrite = "lanWrite" . $i;

                $output .= "<tr><td>".$_GET[$getLanguage]."</td><td>".$_GET[$lanComp]."</td><td>"
                            .$_GET[$lanRead]."</td>"."<td>".$_GET[$lanWrite]."</td></tr>";
        }
            $output .= "<tr><td>Driver's license</td><td colspan='3'>";
            if(isset($_GET["licenseB"])) {
                $output .= "B";
            }
            if(isset($_GET["licenseA"])) {
                if($_GET["licenseB"]) {
                    $output .= ", A";
                }
                else {
                    $output .= "A";
                }
            }
            if(isset($_GET["licenseC"])) {
                if($_GET["licenseB"] || $_GET["licenseA"]) {
                    $output .= ", C";
                }
                else {
                    $output .= "C";
                }
            }
            $output .= " </td></tr></table>";
        }
        echo $output;
    }
?>
</body>
</html>