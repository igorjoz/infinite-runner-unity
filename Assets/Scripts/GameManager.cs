using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //Tworzymy statyczn� zmienn� przechowuj�c� jedyny obiekt klasy GameManager (wg. wzorca Singletonu)
    //Pozwoli to na odwo��nie si� do GameManagera w dowolnym miejscu projektu poprzez GameManager.instance
    public static GameManager instance;
    //Pole na element UI Text s�u��cy do wy�wietlania wyniku
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinScoreText;
    //Pole zawieraj�ce pr�dko�� �wiata do kt�rego b�dzie m�g� odwo�a� si� dowolny obiekt w grze
    //Ustawienie warto�ci nast�puje w edytorze
    public float worldScrollingSpeed;
    //Pole na wynik
    private float score;

    public bool isInGame;
    public GameObject resetButton;

    private int coins;


    // Use this for initialization
    void Start()
    {
        //Podczas uruchomienia przypisujemy aktualn� instancj� do statycznego pola instance
        //!!! Nale�y uwa�a�, �eby zawsze na scenie by� dok�adnie jeden GameManager !!!
        instance = this;

        InitializeGame();
    }
    void FixedUpdate()
    {
        if (!GameManager.instance.isInGame)
        {
            return;
        }

        //Co tick silnika fizyki dopisujemy do wyniku przebyt� odleg�o�� i wywo�ujemy metod� wy�wietlaj�c� wynik na ekranie
        score += worldScrollingSpeed;
        UpdateOnScreenScore();
    }
    void UpdateOnScreenScore()
    {
        //Wy�wietlamy na elemencie nasz wynik bez cz�ci dziesi�tnej
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
}