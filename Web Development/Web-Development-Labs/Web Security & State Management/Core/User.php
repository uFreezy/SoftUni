<?php

namespace Core;

class User
{
    private $id;
    private $user;
    private $pass;
    private $gold;
    private $food;

    const GOLD_DEFAULT = 1500;
    const FOOD_DEFAULT = 1500;

    /**
     * User constructor.
     * @param $id
     * @param $user
     * @param $pass
     * @param $gold
     * @param $food
     */
    public function __construct($id = null, $user, $pass, $gold = null, $food = null)
    {
        $this->setId($id)
            ->setUser($user)
            ->setPass($pass)
            ->setFood($food)
            ->setGold($gold);
    }


    public function getId()
    {
        return $this->id;
    }

    public function setId($id)
    {
        $this->id = $id;
        return $this;

    }


    public function getUser()
    {
        return $this->user;
    }


    public function setUser($user)
    {
        $this->user = $user;
        return $this;
    }

    public function getPass()
    {
        return $this->pass;
    }

    public function setPass($pass)
    {
        $this->pass = $pass; //!!!
        return $this;
    }

    public function getGold()
    {
        return $this->gold;
    }

    public function setGold($gold)
    {
        $this->gold = $gold;
        return $this;
    }

    public function getFood()
    {
        return $this->food;
    }

    public function setFood($food)
    {
        $this->food = $food;
        return $this;
    }
}