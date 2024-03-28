using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getUserAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int index = SelecionarPersonagem.characterIndex;
        string name = SelecionarPersonagem.characterName;
        Debug.Log($"Saiu da tela de usuário - index: {index}, name: {name}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
