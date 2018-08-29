using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuiManager : MonoBehaviour 
{
    public GameObject playerDeadLbl;
    public Text scoreLbl;

    public void OnHomeClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnResetScoreClicked()
    {
        PlayerPrefs.SetInt("Score",0);
        scoreLbl.text = "Score : 0";
    }

    public void OnResetLvlClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowDeadText()
    {
        playerDeadLbl.SetActive(true);
    }
}
