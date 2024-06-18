using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Threading;

public class LogicScript : MonoBehaviour
{
    public int PlayerScore;
    public int HighScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource dingSound;
    public AudioSource gameOverSound;
    public AudioSource spacePressSound; // Drag your spacebar press sound effect here in the Inspector
    public GameObject HappyGuy;
    public Sprite JumpingSprite;
    public Sprite ThumbsSprite;
    private SpriteRenderer SpriteRenderer;
    private float _lastTime;

    private void Start()
    {
        SpriteRenderer = HappyGuy.GetComponent<SpriteRenderer>();
        HighScore = PlayerPrefs.GetInt("highscore");
        highScoreText.text = "High score: " + HighScore.ToString();
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
            SpriteRenderer.sprite = JumpingSprite;
            _lastTime = Time.realtimeSinceStartup;
            // Play the spacebar press sound effect
            PlaySpacePressSound();
        }
        if (Time.realtimeSinceStartup - _lastTime > 0.25)
        {
            _lastTime = Time.realtimeSinceStartup;
            SpriteRenderer.sprite = ThumbsSprite;
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int ScoreToAdd)
    {
        PlayerScore += ScoreToAdd;
        scoreText.text = PlayerScore.ToString();
        PlayDingSound();
        if (PlayerScore > HighScore)
        {
            HighScore = PlayerScore;
            highScoreText.text = "High score: " + HighScore.ToString();
            PlayerPrefs.SetInt("highscore", HighScore);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0.0f;
        SpriteRenderer.sprite = ThumbsSprite;
    }

    public void MainMenu()
    {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver()
    {
        Time.timeScale = 0.0f;
        gameOverScreen.SetActive(true);
        PlayGameOverSound();
        SpriteRenderer.sprite = ThumbsSprite;
    }

    void PlayDingSound()
    {
        if (dingSound != null)
        {
            dingSound.Play();
        }
    }

    void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
    }

    void PlaySpacePressSound()
    {
        if (spacePressSound != null)
        {
            spacePressSound.Play();
        }
    }
}