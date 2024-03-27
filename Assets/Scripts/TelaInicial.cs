using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    public static UnityEngine.UI.Toggle toggle;

    void Start()
    {
        toggle = GameObject.Find("SoundToggle").GetComponent<UnityEngine.UI.Toggle>();

        if (SoundManager.controleMusica)
        {
            toggle.isOn = true;
            BGSound.instance.Audio.Pause();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("EscolhaPersonagem");
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("Creditos");
    }
}
