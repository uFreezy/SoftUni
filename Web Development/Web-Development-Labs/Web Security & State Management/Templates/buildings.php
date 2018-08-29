<h1>Buildings</h1>

<h3>
    Resources:
    <p>Gold: <?= $data->getUser()->getGold() ?></p>
    <p>Food: <?= $data->getUser()->getFood() ?></p>
</h3>
<table border="1">
    <tr>
        <td>Building name</td>
        <td>Level</td>
        <td>Gold</td>
        <td>Food</td>
        <td>Action</td>
    </tr>
    <?php foreach($data->getBuildings() as $building): ?>
        <tr>
            <td><?=$building['name']?></td>
            <td><?=$building['lvl']?></td>
            <td><?=$building['gold']?></td>
            <td><?=$building['food']?></td>
            <td><a href="buildings.php?id=<?=$building['id']?>">Action</a></td>
        </tr>
    <?php endforeach; ?>
</table>