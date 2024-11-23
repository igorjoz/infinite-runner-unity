using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nasz skrypt wymaga, by na tym samym obiekcie znalaz� si� r�wnie� AudioSource
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
            // t�umaczymy dok�adnie t� linijk�
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