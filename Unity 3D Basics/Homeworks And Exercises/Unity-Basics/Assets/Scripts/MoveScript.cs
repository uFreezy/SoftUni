using UnityEngine;

namespace Assets.Scripts
{
    public class MoveScript : MonoBehaviour
    {
        public Transform cube;
        public float speed;

        void Awake()
        {
            Debug.Log("Awake");
            
        }
        // Use this for initialization
        void Start ()
        {
            Debug.Log("Start");
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(0f, 0f, speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(0f, 0f, speed * -1 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(speed * -1 * Time.deltaTime, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }
        }
    }
}
