using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip feedbackPositivo;
    public static AudioClip feedbackNegativo;
    public static AudioClip vitoria;
    public static AudioClip derrota;
    public static AudioClip venceuJogo;
    public static AudioClip pickUp;
    public static AudioClip drop;

    public static bool controleMusica;

    public void Start()
    {
        feedbackPositivo = Resources.Load<AudioClip>("feedbackPositivo");

        feedbackNegativo = Resources.Load<AudioClip>("feedbackNegativo");

        vitoria = Resources.Load<AudioClip>("vitoria");

        venceuJogo = Resources.Load<AudioClip>("venceuJogo");

        derrota = Resources.Load<AudioClip>("perdeufase");

        pickUp = Resources.Load<AudioClip>("pick up");

        drop = Resources.Load<AudioClip>("drop");
    }


    public void MusicToggle()
    {
        if (BGSound.instance.Audio.isPlaying)
        {
            BGSound.instance.Audio.Pause();
            controleMusica = true;
        }
        else
        {
            BGSound.instance.Audio.Play();
            controleMusica = false;
        }

    }
}
