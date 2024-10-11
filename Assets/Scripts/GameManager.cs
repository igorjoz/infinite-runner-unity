using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    //Tworzymy statyczn� zmienn� przechowuj�c� jedyny obiekt klasy GameManager (wg. wzorca Singletonu)
    //Pozwoli to na odwo�anie si� do GameManagera w dowolnym miejscu projektu poprzez wywo�anie GameManager.instance
    public static GameManager instance;
    //Pole zawieraj�ce pr�dko�� �wiata do kt�rego b�dzie m�g� odwo�a� si� dowolny obiekt w grze
    //Domy�lnie ustawiamy 0.2f, ale warto�� mo�na dopasowa� w edytorze
    public float worldScrollingSpeed = 0.2f;
    // Use this for initialization
    void Start()
    {
        //Podczas uruchomienia przypisujemy aktualn� instancj� do statycznego pola instance
        //!!! Nale�y uwa�a�, �eby zawsze na scenie by� dok�adnie jeden GameManager !!!
        if (instance == null) 
        {
            instance = this;
        }
    }
}