using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject floorTile1, floorTile2;

    void FixedUpdate()
    {
        floorTile1.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);
        floorTile2.transform.position -= new Vector3(GameManager.instance.worldScrollingSpeed, 0f, 0f);

        if (floorTile2.transform.position.x < 0f)
        {
            floorTile1.transform.position += new Vector3(32f, 0f, 0f);

            var temp = floorTile1;
            floorTile1 = floorTile2;
            floorTile2 = temp;
        }
    }
}
