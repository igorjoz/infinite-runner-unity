using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{

    public float rotationSpeed = 2f;
    public void Start()
    {
        //Losujemy prêdkoœæ obrotu z zakresu 50% do 150% pierwotnej
        rotationSpeed = Random.Range(0.5f * rotationSpeed, 1.5f * rotationSpeed);
    }
    public void FixedUpdate()
    {
        //Obracamy w osi Z (do ekranu)
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
        // Start is called before the first frame update
    }
}
