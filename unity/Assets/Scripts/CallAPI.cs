using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CallAPI : MonoBehaviour
{
    private string apiUrl = "http://localhost:8000/";

    IEnumerator GetFromAPI()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            // Enviar a solicitação e esperar pela resposta
            yield return webRequest.SendWebRequest();

            // Verificar se ocorreu algum erro durante a solicitação
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Erro ao obter resposta da API: " + webRequest.error);
            }
            else
            {
                // Se a solicitação for bem-sucedida, exibir a resposta da API
                Debug.Log("Resposta da API: " + webRequest.downloadHandler.text);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // Iniciar a rotina para fazer a solicitação à API
        StartCoroutine(GetFromAPI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
