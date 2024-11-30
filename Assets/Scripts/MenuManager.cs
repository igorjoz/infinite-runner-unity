using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreValue;
    public TextMeshProUGUI coinsValue;
    public TextMeshProUGUI soundButtonText;

    float highScore = 0f; // Float for internal high score storage
    int coins = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScoreValue"))
        {
            highScore = PlayerPrefs.GetFloat("HighScoreValue"); // Retrieve as float
            Debug.Log($"High Score Loaded: {Mathf.FloorToInt(highScore)}");
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        // Display high score as integer
        highScoreValue.text = Mathf.FloorToInt(highScore).ToString();
        coinsValue.text = coins.ToString();

        if (SoundManager.instance.GetMuted())
        {
            soundButtonText.text = "TURN SOUND ON";
        }
        else
        {
            soundButtonText.text = "TURN SOUND OFF";
        }
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void SoundButtonClicked()
    {
        SoundManager.instance.ToggleMuted();
        UpdateUI();
    }
}

