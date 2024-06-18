using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public string GameScene;
    public Text highScoreText;
    public void Click()
    {
        SceneManager.LoadScene(GameScene);
        Time.timeScale = 0.0f;
    }

    void Start()
    {
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("highscore");
    }
}
