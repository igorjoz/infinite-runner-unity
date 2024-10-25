using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
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
    // Use this for initialization
    void Start()
    {
        //Podczas uruchomienia przypisujemy aktualn� instancj� do statycznego pola instance
        //!!! Nale�y uwa�a�, �eby zawsze na scenie by� dok�adnie jeden GameManager !!!
        instance = this;
    }
    void FixedUpdate()
    {
        //Co tick silnika fizyki dopisujemy do wyniku przebyt� odleg�o�� i wywo�ujemy metod� wy�wietlaj�c� wynik na ekranie
        score += worldScrollingSpeed;
        UpdateOnScreenScore();
    }
    void UpdateOnScreenScore()
    {
        //Wy�wietlamy na elemencie nasz wynik bez cz�ci dziesi�tnej
        scoreText.text = score.ToString("0");
    }
}