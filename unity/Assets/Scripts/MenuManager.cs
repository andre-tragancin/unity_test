using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class MenuManager : MonoBehaviour
{
    public void RetornarTelaInicial()
    {
        SceneManager.LoadScene("TelaInicial");
    }

    public void RetornarTelaEscolhaPersonagem()
    {
        SceneManager.LoadScene("EscolhaPersonagem");
    }

    public void AbrirMapaFases()
    {
        SceneManager.LoadScene("MapaFases");
    }

    public void AbrirConfiguracoes()
    {
        SceneManager.LoadScene("Configuracoes");
    }
}
