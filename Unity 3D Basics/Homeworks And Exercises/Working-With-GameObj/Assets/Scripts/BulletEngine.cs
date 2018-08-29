using UnityEngine;

public class BulletEngine : MonoBehaviour
{
    private const float Speed = 10;

    private float timeOut = 2;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        this.transform.position += this.transform.forward*(Time.deltaTime*Speed);

        this.timeOut -= Time.deltaTime;
        if (this.timeOut <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}