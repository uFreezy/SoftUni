using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera camera;
    public static bool isGameOver;
    public static bool isPlaying;

    // Use this for initialization
    private void Start()
    {
        this.camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void OnCollisionEnter2D()
    {
        isPlaying = false;
        isGameOver = true;
        Destroy(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touches[0].phase == TouchPhase.Began)
        {
            isPlaying = true;
            this.GetComponent<Rigidbody2D>()
                .AddForce(new Vector2(this.transform.position.x, 1.5f));
            this.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }

    }
}