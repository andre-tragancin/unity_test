using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionarPersonagem : MonoBehaviour
{
    private MenuManager menuManager;
    public static int characterIndex;
    public static string characterName;
    public AudioSource audioSource;

    [SerializeField]
    public GameObject[] characters;

    public GameObject InputNome;

    public Image FeedbackNegativo;
    public Image FlechaInformarNome;
    public Image FlechaInformarAvatar;

    private void Awake()
    {
        menuManager = gameObject.AddComponent<MenuManager>();
    }

    private void Start()
    {
        characterIndex = -1;
        characterName = "";
    }

    public void ChangeCharacter(int index)
    {
        characterIndex = index;
        DesabilitarTodosOsChecks();
        AlterarEstadoCheck(true);
    }

    public void AlterarEstadoCheck(bool estado)
    {
        characters[characterIndex].gameObject.SetActive(estado);
    }

    public void DesabilitarTodosOsChecks()
    {
        foreach (GameObject character in characters)
        {
            character.gameObject.SetActive(false);
        }
    }
    public IEnumerator WaitFeedbackNegativoNome()
    {
        yield return new WaitForSeconds(0.1f);
        FeedbackNegativo.color = Color.white;

        yield return new WaitForSeconds(0.4f);
        FlechaInformarNome.color = Color.white;

    }

    public IEnumerator WaitFeedbackClearNome()
    {
        yield return new WaitForSeconds(1f);
        FeedbackNegativo.color = Color.clear;
        FlechaInformarNome.color = Color.clear;
    }
    private void feedbackNomeObrigatorio()
    {
        audioSource.PlayOneShot(SoundManager.feedbackNegativo);

        FeedbackNegativo.gameObject.SetActive(true);
        FlechaInformarNome.gameObject.SetActive(true);

        StartCoroutine(WaitFeedbackNegativoNome());
        StartCoroutine(WaitFeedbackClearNome());
    }

    public IEnumerator WaitFeedbackNegativoAvatar()
    {
        yield return new WaitForSeconds(0.1f);
        FeedbackNegativo.color = Color.white;

        yield return new WaitForSeconds(0.4f);
        FlechaInformarAvatar.color = Color.white;

    }

    public IEnumerator WaitFeedbackClearAvatar()
    {
        yield return new WaitForSeconds(1f);
        FeedbackNegativo.color = Color.clear;
        FlechaInformarAvatar.color = Color.clear;
    }

    private void feedbackAvatarObrigatorio()
    {
        audioSource.PlayOneShot(SoundManager.feedbackNegativo);

        FeedbackNegativo.gameObject.SetActive(true);
        FlechaInformarAvatar.gameObject.SetActive(true);

        StartCoroutine(WaitFeedbackNegativoAvatar());
        StartCoroutine(WaitFeedbackClearAvatar());
    }
    public void checarDados()
    {
        if (InputNome.GetComponent<Text>().text == "")
        {
            feedbackNomeObrigatorio();
        } else if (characterIndex == -1)
        {
            feedbackAvatarObrigatorio();
        } else
        {
            characterName = InputNome.GetComponent<Text>().text;
            PlayerPrefs.SetInt("CharacterIndex", characterIndex);
            menuManager.AbrirMapaFases();
        }
        
    }
}
