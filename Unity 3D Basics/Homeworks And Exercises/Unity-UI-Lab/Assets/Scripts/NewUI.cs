using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class NewUI : MonoBehaviour
    {
        private bool isFilling;
        public Slider ProgressSlider;


        // Use this for initialization
        private void Start()
        {
        }

        public void Fill()
        {
            if (this.isFilling)
            {
                this.isFilling = false;
            }
            else
            {
                this.isFilling = true;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (this.isFilling)
            {
                this.ProgressSlider.value += 0.005f;
            }
            if (this.ProgressSlider.value == 1)
            {
                this.ProgressSlider.value = 0;
            }
        }
    }
}