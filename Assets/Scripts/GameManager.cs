using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using System.Xml.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //Tworzymy statyczn� zmienn� przechowuj�c� jedyny obiekt klasy GameManager (wg. wzorca Singletonu)
    //Pozwoli to na odwo��nie si� do GameManagera w dowolnym miejscu projektu poprzez GameManager.instance
    public static GameManager instance;
    //Pole na element UI Text s�u��cy do wy�wietlania wyniku
    public TextMeshProUGUI scoreText;
    //Pole zawieraj�ce pr�dko�� �wiata do kt�rego b�dzie m�g� odwo�a� si� dowolny obiekt w grze
    //Ustawienie warto�ci nast�puje w edytorze
    public float worldScrollingSpeed;
    //Pole na wynik
    private float score;

    //pole w kt�rym b�dziemy pami�ta� czy aktualnie trwa gra; lesson8 change
    public bool isInGame;

    //pole do podpi�cia przycisku reset; lesson8 change
    public GameObject resetButton;

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
        //Je�li aktualnie nie trwa gra nie wykonuj reszty metody; lesson8 change
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
    }

    void InitializeGame()
    {
        //Ustawiamy pole m�wi�ce, �e jeste�my w trakcie gry
        isInGame = true;
    }

    public void GameOver()
    {
        //gra si� sko�czy�a, wi�c:
        isInGame = false;
        //Wy�wietlamy przycisk Restart
        resetButton.SetActive(true);
    }

    public void RestartGame()
    {
        //Ponownie �adujemy scen� o indeksie 0 (czyli jedyn� w naszej grze)
        //Spowoduje to reset gry
        SceneManager.LoadScene(0);
    }

}