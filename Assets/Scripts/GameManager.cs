using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    //Tworzymy statyczn¹ zmienn¹ przechowuj¹c¹ jedyny obiekt klasy GameManager (wg. wzorca Singletonu)
    //Pozwoli to na odwo³anie siê do GameManagera w dowolnym miejscu projektu poprzez wywo³anie GameManager.instance
    public static GameManager instance;
    //Pole zawieraj¹ce prêdkoœæ œwiata do którego bêdzie móg³ odwo³aæ siê dowolny obiekt w grze
    //Domyœlnie ustawiamy 0.2f, ale wartoœæ mo¿na dopasowaæ w edytorze
    public float worldScrollingSpeed = 0.2f;
    // Use this for initialization
    void Start()
    {
        //Podczas uruchomienia przypisujemy aktualn¹ instancjê do statycznego pola instance
        //!!! Nale¿y uwa¿aæ, ¿eby zawsze na scenie by³ dok³adnie jeden GameManager !!!
        if (instance == null) 
        {
            instance = this;
        }
    }
}