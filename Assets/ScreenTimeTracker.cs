using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private float startTime;
    private string screenName;
    private testeDB databaseManager;
    // Start is called before the first frame update
    void Start()
    {
        // Obtém o nome da cena atual
        screenName = SceneManager.GetActiveScene().name;
        // Inicia a contagem do tempo quando a tela é ativada
        startTime = Time.time;
        GameObject dbGameObject = GameObject.Find("Script");
        databaseManager = dbGameObject.GetComponent<testeDB>();
    }

    void OnDestroy()
    {
        // Calcula o tempo gasto na tela
        float timeSpent = Time.time - startTime;
        // Converte o tempo para segundos inteiros
        int timeSpentInSeconds = Mathf.RoundToInt(timeSpent);
        // Acessa o componente do banco de dados e atualiza o tempo gasto na tela
        if (databaseManager != null) {
            databaseManager.UpdateScreenTime(screenName, timeSpentInSeconds);
        }
        // FindObjectOfType<DatabaseManager>().UpdateScreenTime(screenName, timeSpentInSeconds);
    }
}
