using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Bullet;
    private bool isInDistance;
    private bool isShooting;

    public GameObject Player;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        this.transform.LookAt(this.Player.transform);

        this.isInDistance = Vector3.Distance(this.Player.transform.position, this.transform.position) < 30;

        if (this.isInDistance && !this.isShooting)
        {
            this.StartCoroutine("EnemyShoot");
            this.isShooting = true;
        }
        else if (!this.isInDistance && this.isShooting)
        {
            this.StopCoroutine("EnemyShoot");
            this.isShooting = false;
        }
    }

    private IEnumerator EnemyShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            var go = Instantiate(this.Bullet);
            go.transform.position = this.transform.position;
            go.transform.LookAt(this.Player.transform.position);
            go.AddComponent<BulletEngine>();
        }
    }
}