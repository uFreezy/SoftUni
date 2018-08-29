using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    //1. Използвайте аксисите "Horizontal", "Vertical" и "Mouse X" за да напраите контролер за движение. Hint - Transform.Translate, Transform.Rotate
    //2. Добавете код, с който при натикане на левия бутон на мишката се истанцира и изтрелва  куршум, който представлява елементарен куб или сфера.
    //3. Куршумът трябва да се изтрелва от позицията на оръжието, което е дете на този обект и да лети в права посока и да се самоунищожи след 2 секунди съществуване.

    private Camera mainCamera;

    private readonly float moveSpeed = 10f;
    GameObject playerGun;
    private readonly float rotationSpeed = 40f;
    
    private Vector3 posToFace;

    // Use this for initialization
    private void Start()
    {
        // Gets the Weapon/Gun object. 
        this.playerGun = GameObject.Find("Weapon");
        // Gets the main camera.
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Gets the position where the main camera is pointed at.
        posToFace = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f));

        // Rotates the player according to the position of Mouse X axis.
        var inputVec = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        this.transform.Rotate(inputVec, Time.deltaTime*this.rotationSpeed);

        // Rotates the gun to point where the mouse is pointed at.
        this.playerGun.transform.LookAt(posToFace);

        // Moving controls.
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward*(Time.deltaTime*this.moveSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back*(Time.deltaTime*this.moveSpeed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left*(Time.deltaTime*this.moveSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right*(Time.deltaTime*this.moveSpeed));
        }      
    }
}