using UnityEngine;
using System.Collections;

public class AirPlaneScript : MonoBehaviour 
{
    public GuiManager guiManager;
    float moveSpeed = 0.05f;
    float zMax = 5f;
    float zMin = -1.8f;
    float xMin = 0.88f;
    float xMax = 7.77f;
    float yCoordinate = 4.43f;
    Camera planeCamera;
    float planeRotateTime = 1f;
    float planeReturnRotationSpeed = 0f;
    float planeReturnDampTime = 0.2f;
    int score;
    public bool isAlive;
    float rotorSpeed = 1000f;
    Rigidbody attachedRigidbody;
    private GameObject planeRotor;

	// Use this for initialization
	void Start ()
    {
        isAlive = true;
	    if (PlayerPrefs.HasKey("Score"))
	    {
	        score = PlayerPrefs.GetInt("Score");
	    }
	    StartCoroutine(this.IncreaseDifficulty());
        guiManager.scoreLbl.text = string.Format("Score : {0}", score.ToString());
        planeCamera = Camera.main;
        attachedRigidbody = GetComponent<Rigidbody>();
        planeRotor = GameObject.Find("Rotor");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (isAlive)
        {
            ManageInput();
            ManageLimitations();
            this.ManageInput();

            planeRotor.transform.Rotate(new Vector3(0,0,rotorSpeed));
        }
        
	}

    void ManageInput()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        if (horizontalAxis > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, -90f, ref planeReturnRotationSpeed, planeRotateTime));
        }
        else if (horizontalAxis < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, 90f, ref planeReturnRotationSpeed, planeRotateTime));
        }
        else if (transform.rotation.eulerAngles != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, 0f, ref planeReturnRotationSpeed, planeReturnDampTime));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                yCoordinate,
                this.transform.position.z + moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(
                this.transform.position.x,
                yCoordinate,
                this.transform.position.z - moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.position = new Vector3(
                this.transform.position.x  - moveSpeed, this.yCoordinate,
                this.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position = new Vector3(
                this.transform.position.x + moveSpeed, this.yCoordinate,
                this.transform.position.z);
        }

    }

    void ManageLimitations()
    {
        float planeToViewPort_Y = planeCamera.WorldToViewportPoint(transform.position).y;
        float zDistance = Mathf.Abs((planeCamera.transform.position - transform.position).z);
        xMin = planeCamera.ViewportToWorldPoint(new Vector3(0f, planeToViewPort_Y, zDistance)).x;
        xMax = planeCamera.ViewportToWorldPoint(new Vector3(1f, planeToViewPort_Y, zDistance)).x;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), yCoordinate, Mathf.Clamp(transform.position.z, zMin, zMax));
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            CrashPlane();
        }
        else if (col.tag == "Coin")
        {
            col.gameObject.SetActive(false);
            score++;
            PlayerPrefs.SetInt("Score",score);
            guiManager.scoreLbl.text = string.Format("Score : {0}", score.ToString());
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        moveSpeed += 0.02f;
        yield return new WaitForSeconds(60f);
        //Debug.Log(string.Format("moveSpeed updated: {0}", moveSpeed));
    }

    void CrashPlane()
    {
        isAlive = false;
        attachedRigidbody.isKinematic = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }

        guiManager.ShowDeadText();
    }
}
