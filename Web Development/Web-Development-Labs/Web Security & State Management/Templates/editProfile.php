<form action="" method="post">
    <div>
        <input type="text" name="username" value="<?= htmlspecialchars($data->getUser()); ?>" />
        <input type="password" name="password" placeholder="Password" />
        <input type="password" name="repeat" placeholder="Confirm password" />
        <input type="submit" name="edit" value="Edit!" />
    </div>
</form>