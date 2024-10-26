using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FloorController : MonoBehaviour
{
    //Pola do kt�rych przypisujemy du�e kafelki z pod�og�
    //Zak�adamy, �e na pocz�tku do floorTile1 jest przypisany lewy kafelek
    public GameObject floorTile1, floorTile2;
    public GameObject[] tiles;

    // UWAGA - korzystamy z metody FixedUpdate, kt�ra wywo�uje si� raz na tick silnika fizyki a nie co klatk�.
    // Pozwoli nam to uniezale�ni� ruchy obiekt�w od ilo�ci wy�wietlanych w danym momencie klatek na sekund�
    void FixedUpdate()
    {
        if (!GameManager.instance.isInGame)
        {
            return;
        }

        //Co tick silnika fizyki przesuwamy oba kafelki o worldScrolingSpeed
        // -= poniewa� chcemy przesuwa� �wiat w lewo, czyli zmniejsza� wsp�rz�dn� X
        floorTile1.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);
        floorTile2.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);

        //Je�li �rodek prawego kafelka przejecha� przez �rodek ekranu (x < 0) lewy kafelek przenosimy

        //na jego praw� stron� i zamieniamy zmienne
        if (floorTile2.transform.position.x < 0f)
        {
            //przesuwam lewy kafelek w prawo o 32 jednostki (czyli 2 jego szeroko�ci)

            int randomTileIndex = Random.Range(0, tiles.Length);
            var newTile = Instantiate(tiles[randomTileIndex], floorTile2.transform.position + new Vector3(16f, 0f, 0f), Quaternion.identity);

            Destroy(floorTile1);

            //Zamieniam zmienne
            floorTile1 = floorTile2;
            floorTile2 = newTile;
        }
    }
}