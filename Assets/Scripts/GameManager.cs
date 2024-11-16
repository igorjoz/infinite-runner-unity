using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using MyGame.Powerups;
public class GameManager : MonoBehaviour
{
    //Tworzymy statyczn¹ zmienn¹ przechowuj¹c¹ jedyny obiekt klasy GameManager (wg. wzorca Singletonu)
    //Pozwoli to na odwo³¹nie siê do GameManagera w dowolnym miejscu projektu poprzez GameManager.instance
    public static GameManager instance;
    //Pole na element UI Text s³u¿¹cy do wyœwietlania wyniku
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinScoreText;
    //Pole zawieraj¹ce prêdkoœæ œwiata do którego bêdzie móg³ odwo³aæ siê dowolny obiekt w grze
    //Ustawienie wartoœci nastêpuje w edytorze
    public float worldScrollingSpeed;
    //Pole na wynik
    private float score;

    public bool isInGame;
    public GameObject resetButton;

    private int coins;

    public Immortality immortality;
    public Magnet magnet;


    // Use this for initialization
    void Start()
    {
        //Podczas uruchomienia przypisujemy aktualn¹ instancjê do statycznego pola instance
        //!!! Nale¿y uwa¿aæ, ¿eby zawsze na scenie by³ dok³adnie jeden GameManager !!!
        instance = this;

        InitializeGame();
    }
    void FixedUpdate()
    {
        if (!GameManager.instance.isInGame)
        {
            return;
        }

        //Co tick silnika fizyki dopisujemy do wyniku przebyt¹ odleg³oœæ i wywo³ujemy metodê wyœwietlaj¹c¹ wynik na ekranie
        score += worldScrollingSpeed;
        UpdateOnScreenScore();
    }
    void UpdateOnScreenScore()
    {
        //Wyœwietlamy na elemencie nasz wynik bez czêœci dziesiêtnej
        scoreText.text = score.ToString("0");
        coinScoreText.text = coins.ToString("0");
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

        UpdateOnScreenScore();

        immortality.isActive = false;
        magnet.isActive = false;
    }

    public void HandleGameOver()
    {
        isInGame = false;
        resetButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void HandleCoinCollection(int coinValue = 1)
    {
        coins += coinValue;
        PlayerPrefs.SetInt("Coins", coins);
        UpdateOnScreenScore();
    }

    public void ImmortalityCollected()
    {
        //Jeœli gracz ju¿ jest nieœmiertelny anulujemy invoke z wy³¹czeniem nieœmiertelnoœci i sami anulujemy nieœmiertelnoœæ by j¹ potem w³¹czyæ(spowoduje to przed³u¿enie czasu jej trwania)
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

    public void MagnetCollected()
    {
        if (magnet.isActive)
            CancelInvoke("CancelMagnet");
        magnet.isActive = true;
        Invoke("CancelMagnet", magnet.GetDuration());
    }
    private void CancelMagnet()
    {
        magnet.isActive = false;
    }
}