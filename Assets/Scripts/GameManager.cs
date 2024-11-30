using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinScoreText;

    public float worldScrollingSpeed;

    private float score; // Float for internal score calculation
    private float highScoreValue; // Float for internal high score calculation

    public bool isInGame;
    public GameObject resetButton;

    private int coins;
    public Immortality immortality;

    void Start()
    {
        instance = this;
        InitializeGame();
    }

    void FixedUpdate()
    {
        if (!isInGame) return;

        score += worldScrollingSpeed * Time.fixedDeltaTime; // Accumulate score as float
        UpdateOnScreenScore();
    }

    void UpdateOnScreenScore()
    {
        // Display scores as integers
        scoreText.text = Mathf.FloorToInt(score).ToString();
        coinScoreText.text = coins.ToString();
    }

    void InitializeGame()
    {
        isInGame = true;

        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            coins = 0;
            PlayerPrefs.SetInt("Coins", 0);
        }

        if (PlayerPrefs.HasKey("HighScoreValue"))
        {
            highScoreValue = PlayerPrefs.GetFloat("HighScoreValue"); // Retrieve as float
        }
        else
        {
            highScoreValue = 0f;
            PlayerPrefs.SetFloat("HighScoreValue", highScoreValue);
        }

        UpdateOnScreenScore();
        immortality.isActive = false;
    }

    public void HandleGameOver()
    {
        isInGame = false;
        resetButton.SetActive(true);

        if (score > highScoreValue)
        {
            highScoreValue = score;
            PlayerPrefs.SetFloat("HighScoreValue", highScoreValue); // Save as float
            Debug.Log($"New High Score Saved: {Mathf.FloorToInt(highScoreValue)}");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void HandleCoinCollection(int coinValue = 1)
    {
        coins += coinValue;
        PlayerPrefs.SetInt("Coins", coins);
        UpdateOnScreenScore();
    }

    public void HandleImmortalityCollection()
    {
        if (immortality.isActive)
        {
            CancelInvoke("CancelImmortality");
            CancelImmortality();
        }

        immortality.isActive = true;
        worldScrollingSpeed += immortality.GetSpeedBoost();
        Invoke("CancelImmortality", immortality.GetDuration());
    }

    private void CancelImmortality()
    {
        worldScrollingSpeed -= immortality.GetSpeedBoost();
        immortality.isActive = false;
    }
}


