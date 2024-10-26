using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using System.Xml.Linq;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //Tworzymy statyczn¹ zmienn¹ przechowuj¹c¹ jedyny obiekt klasy GameManager (wg. wzorca Singletonu)
    //Pozwoli to na odwo³¹nie siê do GameManagera w dowolnym miejscu projektu poprzez GameManager.instance
    public static GameManager instance;
    //Pole na element UI Text s³u¿¹cy do wyœwietlania wyniku
    public TextMeshProUGUI scoreText;
    //Pole zawieraj¹ce prêdkoœæ œwiata do którego bêdzie móg³ odwo³aæ siê dowolny obiekt w grze
    //Ustawienie wartoœci nastêpuje w edytorze
    public float worldScrollingSpeed;
    //Pole na wynik
    private float score;

    //pole w którym bêdziemy pamiêtaæ czy aktualnie trwa gra; lesson8 change
    public bool isInGame;

    //pole do podpiêcia przycisku reset; lesson8 change
    public GameObject resetButton;

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
        //Jeœli aktualnie nie trwa gra nie wykonuj reszty metody; lesson8 change
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
    }

    void InitializeGame()
    {
        //Ustawiamy pole mówi¹ce, ¿e jesteœmy w trakcie gry
        isInGame = true;
    }

    public void GameOver()
    {
        //gra siê skoñczy³a, wiêc:
        isInGame = false;
        //Wyœwietlamy przycisk Restart
        resetButton.SetActive(true);
    }

    public void RestartGame()
    {
        //Ponownie ³adujemy scenê o indeksie 0 (czyli jedyn¹ w naszej grze)
        //Spowoduje to reset gry
        SceneManager.LoadScene(0);
    }

}