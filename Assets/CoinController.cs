using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Transform _player;
    private GameManager _gm;
    //Na pocz¹tku przypisujemy sobie lokalne zmienne (coinów mo¿e byæ du¿o, wiêc wolimy szukaæ obiektów tylko raz zamiast na ka¿dym co klatkê
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
        //Jeœli w ogóle mamy magnes
        if (!_gm.magnet.isActive) return;
        //sprawdzamy czy odleg³oœæ pomiêdzy graczem a coinem jest wystarczaj¹co ma³a
        if (Vector3.Distance(transform.position, _player.position) < _gm.magnet.GetRange())
        {
            //Odejmujemy wektor pozycji coina od wektora pozycji gracza
            //Po normalizacji daje nam to wektor kierunku w którym musimy siê poruszaæ w stronê gracza
            var direction = (_player.position - transform.position).normalized;
            //Przesuwamy siê siê w stronê gracza z prêdkoœci¹ ustawion¹ w GameManagerze
            transform.position += direction * _gm.magnet.GetSpeed();
        }
    }
}
