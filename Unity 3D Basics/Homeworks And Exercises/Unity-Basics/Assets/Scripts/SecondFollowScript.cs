using UnityEngine;

namespace Assets.Scripts
{
    public class SecondFollowScript : MonoBehaviour
    {

        public Transform cube;
        public float followSpeed;
        public float minDistance;

        // Update is called once per frame
        private void LateUpdate()
        {
            if (this.cube != null)
            {
                this.transform.LookAt(this.cube);

                if (Vector3.Distance(this.transform.position, this.cube.position) > this.minDistance)
                {
                    this.transform.Translate(0f, 0f, this.followSpeed*Time.deltaTime);
                }
            }
        }
    }
}
