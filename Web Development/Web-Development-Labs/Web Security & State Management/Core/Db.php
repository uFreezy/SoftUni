<?php

namespace Core;

use Core\Drivers\DriverFactory;

class Db
{
    static $inst = array();

    //Holds the PDO instance.
    private $db;

    /**
     * Db constructor.
     * @param $db
     */
    //Takes PDO instance and assign it to the db field.
    private function __construct(\PDO $db)
    {
        $this->db = $db;
    }

    // Returns the given instance from the array of instances.
    public static function getInstance($instanceName = "default"){
        if(!isset(self::$inst[$instanceName])){
            throw new \Exception("Instance with that name was not set");
        }

        return self::$inst[$instanceName];
    }

    //Sets the instance in the array.
    public static function setInstance(
        $instanceName,
        $driver,
        $user,
        $pass,
        $dbName,
        $host = null // Not all databases require it.
    ){

        $driver = DriverFactory::Create($driver,$user,$pass, $dbName,$host);

        $pdo = new \PDO(
            $driver->getDsn(),
            $user,
            $pass
        );

        self::$inst[$instanceName] = new self($pdo);
    }

    /**
     * @param string $statement
     * @param array $driverOptions
     * @return Statement
     */
    public function prepare($statement,array $driverOptions = []){
        $statement = $this->db->prepare($statement, $driverOptions);

        return new Statement($statement);
    }

    public  function query($query){
        return $this->db->query($query);
    }

    public function lastId($name = null){
        return $this->db->lastInsertId($name);
    }

}

class Statement{

    /**
     * @var \PDOStatement
     */
    private $stmt;

    /**
     * Statement constructor.
     * @param \PDOStatement $stmt
     */
    public function __construct(\PDOStatement $stmt)
    {
        $this->stmt = $stmt;
    }


    public function fetch($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetch($fetchStyle);
    }

    public function fetchAll($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetchAll($fetchStyle);
    }

    public function bindParam(
        $parameter,
        &$variable,
        $dataType = \PDO::PARAM_STR,
        $length = null,
        $driverOptions = null){

        return $this->stmt->bindParam($parameter, $variable, $dataType, $length, $driverOptions);

    }

    public function execute($params = array()){
        return $this->stmt->execute($params);
    }

    public function rowCount(){
        return $this->stmt->rowCount();
    }

}