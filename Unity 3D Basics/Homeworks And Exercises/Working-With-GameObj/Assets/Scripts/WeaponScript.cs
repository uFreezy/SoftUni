using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    private Camera mainCamera;

    private Vector3 posToFace;
    public GameObject Bullet;

    // Use this for initialization
    void Start ()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f));

        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(this.Bullet);
            go.transform.position = this.transform.position;
            go.transform.LookAt(posToFace);
            go.AddComponent<BulletEngine>();
        }
    }
}
