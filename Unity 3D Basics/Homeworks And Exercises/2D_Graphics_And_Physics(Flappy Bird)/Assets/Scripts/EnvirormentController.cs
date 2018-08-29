using UnityEngine;

public class EnvirormentController : MonoBehaviour
{
    private bool isGenerating;
    public GameObject Obstacle;


    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (!this.isGenerating && PlayerController.isPlaying)
        {
            this.isGenerating = true;
            this.InvokeRepeating("CreateObstacle", 1, 3.5f);
        }

        else if (this.isGenerating && !PlayerController.isPlaying)
        {
            this.CancelInvoke();
        }
    }

    private void CreateObstacle()
    {
        float randY = Random.Range(-0.5f, -1.0f);
        Instantiate(this.Obstacle, new Vector3(1.5f, randY, 0), Quaternion.identity);
    }
}