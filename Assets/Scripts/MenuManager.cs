using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreValue;
    public TextMeshProUGUI coinsValue;
    public TextMeshProUGUI soundBtnText;
    int hs = 0;
    int coins = 0;
    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScoreValue"))
        {
            hs = PlayerPrefs.GetInt("HighScoreValue");
        }
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        UpdateUI();
    }
    public void UpdateUI()
    {
        highScoreValue.text = hs.ToString();
        coinsValue.text = coins.ToString();
        if (SoundManager.instance.GetMuted())
        {
            soundBtnText.text = "TURN ON SOUND";
        }
        else
        {
            soundBtnText.text = "TURN OFF SOUND";
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void SoundButton()
    {
        SoundManager.instance.ToggleMuted();
        UpdateUI();
    }
}
