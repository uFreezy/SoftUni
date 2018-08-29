<?php

namespace Core;

class App
{
    /**
     * @var Db
     */
    private $db;

    /**
     * @var User
     */
    private $user = null;

    /**
     * @var BuildingsRepo
     */
    private $buildingsRepo;

    /**
     * App constructor.
     * @param Db $db
     */

    public function __construct(Db $db)
    {
        $this->db = $db;
    }

    public function isLogged(){
        return isset($_SESSION["user_id"]);
    }

    /**
     * @param $username
     * @return bool
     */
    public function userExists($username){
        $result = $this->db->prepare("SELECT id FROM users WHERE username = ?");
        var_dump([$username]);
        $result->execute([ $username ]);

        return $result->rowCount() > 0;

    }

    public function register($username, $password){
        if($this->userExists($username)){

            throw new \Exception("User already exists.");
        }

        $result = $this->db->prepare("INSERT INTO users (username, password, gold , food)
        VALUES (?, ? ,?, ?);");

        $result->execute([
            $username,
            password_hash($password, PASSWORD_DEFAULT),
            User::GOLD_DEFAULT,
            User::FOOD_DEFAULT
        ]);

        if($result->rowCount() > 0){
            $userId = $this->db->lastId();

            $this->db->query("INSERT INTO userbuildings (user_id, building_id, level_id)
            SELECT $userId, id, 0 FROM buildings");

            return true;
        }

        throw new \Exception("Cannot register user.");
    }

    public function login($username, $password)
    {
        $result = $this->db->prepare("SELECT id, username, password, gold, food
        FROM users WHERE username = ?");

        $result->execute([
            $username
        ]);

        if($result->rowCount() == 0){
            throw new \Exception("Invalid username");
        }

        $userRow = $result->fetch();

        if(password_verify($password,$userRow["password"])){
            $_SESSION["user_id"] = $userRow["id"];

            $user = new User(
                $userRow["id"],
                $userRow["username"],
                $userRow["password"],
                $userRow["gold"],
                $userRow["food"]
            );

            return $user;
        }
        throw new \Exception("Invalid password.");
    }

    public function getUserInfo($id){
        $result = $this->db->prepare("
          SELECT
              id, username, password, gold, food
          FROM
            users
          WHERE id = ?");

        $result->execute([$id]);

        return $result->fetch();
    }

    /**
     * @return User|null
     */
    public function getUser(){
        if($this->user != null){
            return $this->user;
        }

        if($this->isLogged()){
            $userRow = $this->getUserInfo($_SESSION["user_id"]);

            $this->user = $user = new User(
                $userRow["id"],
                $userRow["username"],
                $userRow["password"],
                $userRow["gold"],
                $userRow["food"]
            );

            return $this->user;
        }

        return null;
    }

    public function editUser(User $user){
        $result = $this->db->prepare("UPDATE users SET username = ?, password = ? WHERE id = ?");

        $result->execute([
            $user->getUser(),
            $user->getPass(),
            $user->getId()
        ]);

        return $result->rowCount() > 0;
    }

    /**
     * @return BuildingsRepo
     */
    public function createBuildings(){
        if($this->buildingsRepo == null){
            $this->buildingsRepo = new BuildingsRepo($this->db, $this->getUser());
        }

        return $this->buildingsRepo;
    }
}