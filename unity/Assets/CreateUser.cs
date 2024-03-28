using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUser : MonoBehaviour
{
    private testeDB databaseManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject dbGameObject = GameObject.Find("TesteSelectUserDB");
        databaseManager = dbGameObject.GetComponent<testeDB>();
    }

    void OnDestroy()
    {
        int index = SelecionarPersonagem.characterIndex;
        string name = SelecionarPersonagem.characterName;
        Debug.Log($"Saiu da tela de Usuário - index: {index}, name: {name}");
        if (databaseManager != null) {
            databaseManager.InsertUser(name, index);
        }
    }

}
