using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] charactersAvatars; 

    public GameObject textName;
    void Start()
    {
        foreach (GameObject character in charactersAvatars)
        {
            character.gameObject.SetActive(false);
        }

        charactersAvatars[SelecionarPersonagem.characterIndex].gameObject.SetActive(true);

        textName.gameObject.GetComponent<Text>().text = SelecionarPersonagem.characterName;
    }
}
