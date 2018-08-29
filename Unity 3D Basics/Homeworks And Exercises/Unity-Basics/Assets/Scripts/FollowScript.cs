using UnityEngine;

namespace Assets.Scripts
{
    public class FollowScript : MonoBehaviour
    {
        public Transform sphere;
        public float followSpeed;
        public float minDistance;

        // Update is called once per frame
        void LateUpdate ()
        {
            if (this.sphere != null)
            {
                this.transform.LookAt(this.sphere);

                if (Vector3.Distance(this.transform.position, this.sphere.position) > this.minDistance)
                {
                    this.transform.Translate(0f, 0f, this.followSpeed * Time.deltaTime);
                }
            }

        }
    }
}
