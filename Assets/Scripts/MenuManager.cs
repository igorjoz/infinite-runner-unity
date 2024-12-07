using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreValue;
    public TextMeshProUGUI coinsValue;
    public TextMeshProUGUI soundButtonText;

    public GameObject mainMenuPanel;
    public GameObject upgradeStorePanel;

    public Text immortalityLevelText;
    public Text immortalityButtonText;

    public Powerup immortality;

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

        mainMenuPanel.SetActive(true);
        upgradeStorePanel.SetActive(false);

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

        immortalityLevelText.text = immortality.ToString();
        immortalityButtonText.text = immortality.UpgradeCostString();
    }

    public void ImmortalityUpgradeButtonClick()
    {
        UpgradePowerup(immortality);
    }

    public void UpgradePowerup(Powerup powerup)
    {
        if (coins >= powerup.GetNextUpgradeCost() && !powerup.IsMaxedOut())
        {
            coins -= powerup.GetNextUpgradeCost();
            PlayerPrefs.SetInt("Coins", coins);
            powerup.Upgrade();
            UpdateUI();
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

    public void UpgradeStoreButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        upgradeStorePanel.SetActive(true);
    }

    public void CloseUpgradeStoreButtonClicked()
    {
        mainMenuPanel.SetActive(true);
        upgradeStorePanel.SetActive(false);
    }
}
