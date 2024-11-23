using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nasz skrypt wymaga, by na tym samym obiekcie znalaz³ siê równie¿ AudioSource
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private bool muted;
    private AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // t³umaczymy dok³adnie tê linijkê
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void ToggleMuted()
    {
        muted = !muted;
        audioSource.mute = muted;
    }
    public bool GetMuted()
    {
        return muted;
    }
}