using UnityEngine;

public class GuiTexture : MonoBehaviour
{
    private GUITexture texture;

    // Use this for initialization
    private void Start()
    {
        this.texture = this.GetComponent<GUITexture>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && this.texture.HitTest(Input.mousePosition))
        {
            Debug.Log(string.Format("GUITexture button clicked! X: {0} Y: {1}",
                Input.mousePosition.x, Input.mousePosition.y));
        }
    }
}