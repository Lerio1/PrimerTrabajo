using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public static AudioManager manager;

    private void Awake()
    {
        manager = this;
    }

    public void ReproducirSonidoFx(AudioClip _elSonidito)
    {
        audioSource.PlayOneShot(_elSonidito);
    }


}
