using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FloorController : MonoBehaviour
{
    //Pola do których przypisujemy du¿e kafelki z pod³og¹
    //Zak³adamy, ¿e na pocz¹tku do floorTile1 jest przypisany lewy kafelek
    public GameObject floorTile1, floorTile2;
    public GameObject[] tiles;

    // UWAGA - korzystamy z metody FixedUpdate, która wywo³uje siê raz na tick silnika fizyki a nie co klatkê.
    // Pozwoli nam to uniezale¿niæ ruchy obiektów od iloœci wyœwietlanych w danym momencie klatek na sekundê
    void FixedUpdate()
    {
        if (!GameManager.instance.isInGame)
        {
            return;
        }

        //Co tick silnika fizyki przesuwamy oba kafelki o worldScrolingSpeed
        // -= poniewa¿ chcemy przesuwaæ œwiat w lewo, czyli zmniejszaæ wspó³rzêdn¹ X
        floorTile1.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);
        floorTile2.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);

        //Jeœli œrodek prawego kafelka przejecha³ przez œrodek ekranu (x < 0) lewy kafelek przenosimy

        //na jego praw¹ stronê i zamieniamy zmienne
        if (floorTile2.transform.position.x < 0f)
        {
            //przesuwam lewy kafelek w prawo o 32 jednostki (czyli 2 jego szerokoœci)

            int randomTileIndex = Random.Range(0, tiles.Length);
            var newTile = Instantiate(tiles[randomTileIndex], floorTile2.transform.position + new Vector3(16f, 0f, 0f), Quaternion.identity);

            Destroy(floorTile1);

            //Zamieniam zmienne
            floorTile1 = floorTile2;
            floorTile2 = newTile;
        }
    }
}