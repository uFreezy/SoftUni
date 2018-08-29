using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    public PlayerControllerScript playerScript;
    public GameObject UIMenu;
    public Transform[] spawnPositions;
    public GameObject floatingLandPrefab;
    public Button PauseButton;
    FloorPieceScript[] floorPieces;
    float nextSpawnTime;
    float minTimeBetweenLandSpawn = 1.5f;
    float maxTimeBetweenLandSpawn = 3f;

    GameObject[] pool;
    private GameObject landParent;
    FloatingLandScript[]  floatingLandScripts;

    void Start()
    {
        PopulatePool();
    }

    void Awake()
    {
        floorPieces = transform.GetComponentsInChildren<FloorPieceScript>();
        nextSpawnTime = Random.Range(minTimeBetweenLandSpawn, maxTimeBetweenLandSpawn);
        PauseGame();
    }

    void PopulatePool()
    {
        this.landParent = GameObject.Find("FloatingLandParent");
        int count = landParent.transform.childCount;
        pool = new GameObject[count];
        floatingLandScripts = new FloatingLandScript[count];

        for (int i = 0; i < count; i++)
        {
            pool[i] = landParent.transform.GetChild(i).gameObject;
            floatingLandScripts[i] = pool[i].GetComponent<FloatingLandScript>();
        }

    }

    void Update()
    {
        if (!playerScript.isMoving)
        {
            return;
        }

        nextSpawnTime -= Time.deltaTime;

        if (nextSpawnTime <= 0f)
        {
            nextSpawnTime = Random.Range(minTimeBetweenLandSpawn, maxTimeBetweenLandSpawn);
            SpawnNewLand();
        }
    } 

    void SpawnNewLand()
    {
        GameObject newLand = GetFreeFloatingLand();

        if (newLand == null)
        {
            return;
        }

        newLand.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        newLand.gameObject.SetActive(true);
    }


    GameObject GetFreeFloatingLand()
    {
        int count = pool.Length;
        for (int i = 0; i < count; i++)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                GameObject item = pool[i];
                item.SetActive(true);
                return item;
            }
        }

        return null;
    }

    public void PauseGame()
    {
        int count = floorPieces.Length;

        for (int i = 0; i < count; i++)
        {
            floorPieces[i].isMoving = false;
        }


        playerScript.isMoving = false;
        playerScript.attachedRigidbody.Sleep();
        UIMenu.SetActive(true);
        PauseButton.gameObject.SetActive(false);
    }

    public void UnPauseGame()
    {
        int count = floorPieces.Length;

        for (int i = 0; i < count; i++)
        {
            floorPieces[i].isMoving = true;
        }

        playerScript.isMoving = true;
        playerScript.attachedRigidbody.WakeUp();
        UIMenu.SetActive(false);
        PauseButton.gameObject.SetActive(true);
    }

    public void ObjPause(bool isMoving)
    {
        for (int i = 0; i < floatingLandScripts.Length; i++)
        {
            floatingLandScripts[i].isMoving = isMoving;
        }
    }
}
