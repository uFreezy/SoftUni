using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   // private bool isGamePlaying;
    private GameObject score;
    public GameObject GameOver;
    //public Button RestartButton;

    // Use this for initialization
    private void Start()
    {
        this.score = GameObject.Find("score");
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerController.isPlaying)
        {
            Destroy(GameObject.Find("logo"));
            this.UpdateScore();
        }
        if (PlayerController.isGameOver && !GameObject.Find("GameOver(Clone)"))
        {
            this.GameOverScreen();
        }
    }

    private void UpdateScore()
    {
        // TODO
        if (!this.score.GetComponent<SpriteRenderer>().enabled)
        {
            this.score.GetComponent<SpriteRenderer>().enabled = true;
        }   
    }

    private void GameOverScreen()
    {
        Destroy(score);
        Instantiate(GameOver, new Vector3(0.2f, 1.2f, 0), Quaternion.identity);
        var restartButton = GameObject.Find("Restart");
        restartButton.GetComponent<Image>().enabled = true;
        restartButton.GetComponent<Button>().enabled = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}