using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour
{
    float resetCoordinate_Z = -20.44f;
    float speed = -5f;
    float rotateSpeed = 100f;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);

        transform.Translate(transform.InverseTransformDirection(Vector3.forward) * speed * Time.deltaTime);

        if (transform.position.z < resetCoordinate_Z)
        {
            gameObject.SetActive(false);
        }     
    }
}
