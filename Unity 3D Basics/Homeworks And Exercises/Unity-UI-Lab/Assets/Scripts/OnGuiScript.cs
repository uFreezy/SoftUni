using UnityEngine;

public class OnGuiScript : MonoBehaviour
{
    private GUITexture textureButton;

    // Use this for initialization
    private void Start()
    {
        this.textureButton = this.GetComponent<GUITexture>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 50, 100, 50), "OnGUI"))
        {
            Debug.Log("Clicked the OnGUI button.");
        }         
    }
}