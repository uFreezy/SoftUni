<?php

namespace Core;

class BuildingsRepo
{
    /**
     * @var Db
     */
    private $db;

    /**
     * @var User
     */
    private $user;

    /**
     * BuildingsRepo constructor.
     * @param Db $db
     * @param User $user
     */
    public function __construct(Db $db, User $user)
    {
        $this->db = $db;
        $this->user = $user;
    }

    public function getBuildings(){
        $result = $this->db->prepare("SELECT
            ub.id,
            b.name,
            lv.lvl,
            lvl.food,
            lvl.gold
        FROM
          userbuildings ub
        INNER JOIN
          buildings b ON ub.building_id = b.id
        INNER JOIN
          buildinglvldefs lv ON ub.level_id = lv.id
        INNER JOIN
          buildinglvldefs lvl ON ub.level_id + 1 = lvl.id
        WHERE
          ub.user_id = ?
        ");

        $result->execute([$_SESSION["user_id"]]);

        return $result->fetchAll();
    }


    public function lvlCompare($buildingId)
    {
        $maxLvl = $this->db->prepare("SELECT
          MAX(lvl) AS 'max_level'
        FROM
          buildinglvldefs
        WHERE
          building_id = (SELECT
                          building_id
                         FROM
                           userbuildings
                         WHERE
                         id = ?)
         ");

        $curLvl = $this->db->prepare("SELECT
          bd.lvl as lvl
        FROM
          buildinglvldefs bd
        INNER JOIN
          userbuildings ub
          ON bd.id = ub.level_id
        WHERE
          ub.id = ?");


        $maxLvl->execute([$buildingId]);

        $curLvl->execute([$buildingId]);

        $maxLvl = intval($maxLvl->fetch()['max_level']);
        $curLvl = intval($curLvl->fetch()['lvl']);

        //var_dump(intval($maxLvl->fetch()['max_level']), intval($curLvl->fetch()['lvl']));
       // var_dump(intval($maxLvl->fetch()['max_level']) > intval($curLvl->fetch()['lvl']));
        return $maxLvl > $curLvl;
    }

    public function evolve($buildingId){
        $buildingCost = $this->db->prepare("SELECT
            lvl.food,
            lvl.gold
        FROM
          userbuildings ub
        INNER JOIN
          buildinglvldefs lvl ON ub.level_id + 1 = lvl.id
        WHERE
          ub.id = ?");

        $buildingCost->execute([$buildingId]);
        $buildingCost = $buildingCost->fetch();


        if($this->user->getGold() <  $buildingCost['gold'] ||
           $this->user->getFood() < $buildingCost['food']){

            throw new \Exception("Not enough resources.");
        }


        if(!$this->lvlCompare($buildingId)){
            throw new \Exception('Max level reached.');
        }

        $this->user->setGold($this->user->getGold() - $buildingCost['gold']);
        $this->user->setFood($this->user->getFood() - $buildingCost['food']);

        $update = $this->db->prepare("UPDATE
          userbuildings
        SET
          level_id = level_id + 1
        WHERE
          user_id = ?
        AND
          id = ?");

        $update->execute([$_SESSION["user_id"], $buildingId]);



    }

    /**
     * @return User
     */
    public function getUser()
    {
        return $this->user;
    }


}