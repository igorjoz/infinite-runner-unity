using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Transform _player;
    private GameManager _gm;
    //Na pocz�tku przypisujemy sobie lokalne zmienne (coin�w mo�e by� du�o, wi�c wolimy szuka� obiekt�w tylko raz zamiast na ka�dym co klatk�
void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if (_gm == null)
        {
            _gm = GameManager.instance;
        }
        //Je�li w og�le mamy magnes
        if (!_gm.magnet.isActive) return;
        //sprawdzamy czy odleg�o�� pomi�dzy graczem a coinem jest wystarczaj�co ma�a
        if (Vector3.Distance(transform.position, _player.position) < _gm.magnet.GetRange())
        {
            //Odejmujemy wektor pozycji coina od wektora pozycji gracza
            //Po normalizacji daje nam to wektor kierunku w kt�rym musimy si� porusza� w stron� gracza
            var direction = (_player.position - transform.position).normalized;
            //Przesuwamy si� si� w stron� gracza z pr�dko�ci� ustawion� w GameManagerze
            transform.position += direction * _gm.magnet.GetSpeed();
        }
    }
}
