using UnityEngine;
using System.Collections;

public class RocketEngine : MonoBehaviour {


    float timeOut = 3;
    float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += this.transform.forward * (Time.deltaTime * speed);
        
        timeOut -= Time.deltaTime;
        if (timeOut <= 0f)
        {
            Destroy(this.gameObject);
        }
	}



}
