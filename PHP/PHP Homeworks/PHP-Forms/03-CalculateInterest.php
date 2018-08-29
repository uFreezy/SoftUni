<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Calculate Interest</title>
    <style>
        section {
            display: block;
        }
    </style>
</head>
<body>
<form method="get">
    <section>
        <label for="amount">Enter amount:</label>
        <input type="text" name="amount"/>
    </section>
    <section>
        <label for="usd">USD</label>
        <input type="checkbox" name="usd"/>
        <label for="eur">EUR</label>
        <input type="checkbox" name="eur"/>
        <label for="bgn">BGN</label>
        <input type="checkbox" name="bgn"/>
    </section>
    <section>
        <label for="compound" id="compound">Compound interest amount:</label>
        <input type="text" name="compound" />
    </section>
    <section>
        <select name="period">
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="60">5 Years</option>
        </select>
        <input type="submit" value="Calculate" />
    </section>
</form>
<?php
if(isset($_GET["compound"])) {
    $monthly = ($_GET["compound"] / 12) / 100;
    $result = $_GET["amount"];

    for($i = 0; $i < $_GET["period"]; $i++) {
        $result += $result * $monthly;
    }
    if(isset($_GET["usd"])) {
        echo "$  " . number_format($result, 2, ".", "");
    }
    else if(isset($_GET["eur"])) {
        echo number_format($result, 2, ".", "") . "  €";
    }
    else if(isset($_GET["bgn"])) {
        echo number_format($result, 2, ".", "") . "  лв";
    }
    else {
        echo "Choose currency please.";
    }
}
?>
</body>
</html>