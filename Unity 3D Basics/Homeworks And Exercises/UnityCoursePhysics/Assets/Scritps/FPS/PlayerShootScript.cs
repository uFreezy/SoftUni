using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    //Допълнете скрипта, по следния начин:
    //С левия бутон на мишката трябва да стреля
    //Трябва да има два режима на стрелба, които се сменят с клавиши 1 и 2 Keycode.Alpha1/Keycode.Alpha2
    //Режим 1 прави "дупка в стената" като просто инстанцира bulletholepfb и го слага в точката на удара (raycast) и му прави ротацията като на уцеления обект
    //Режим 2 инстанцира bulletPfb и го изтрелва от позиция/ротация newBulletPosition чрез rigibody.AddRelativeForce

    public GameObject BulletHolePfb;
    public GameObject BulletPfb;

    private bool isInBulletHoleMode;
    private Camera mainCam;
    public GameObject NewBulletPosition;

    private void Start()
    {
        this.mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.isInBulletHoleMode = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.isInBulletHoleMode = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (this.isInBulletHoleMode)
            {
                var ray = new Ray(this.mainCam.transform.position, this.mainCam.transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var holePos = new Vector3(hit.point.x, hit.point.y, hit.point.z - 0.05f);
                    var bulletHole = Instantiate(this.BulletHolePfb);
                    bulletHole.SetActive(true);
                    bulletHole.transform.position = holePos;
                    bulletHole.transform.rotation = hit.transform.rotation;
                }
            }
            else
            {
                var bullet = Instantiate(this.BulletPfb);
                bullet.SetActive(true);
                bullet.transform.position = this.NewBulletPosition.transform.position;
                bullet.transform.rotation = this.NewBulletPosition.transform.rotation;
                bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 5000));
            }
        }
    }
}