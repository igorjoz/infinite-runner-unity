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

    int highScore = 0;
    int coins = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        highScoreValue.text = highScore.ToString();
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
