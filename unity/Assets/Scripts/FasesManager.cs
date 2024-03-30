using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class FasesManager : MonoBehaviour
{
    [SerializeField] private GameObject panelSairFase;
    [SerializeField] private GameObject panelAcabouFase, panelPerdeuFase;
    [SerializeField] private GameObject panelScore, panelVida, _objSetas, _objRoupas;
    [SerializeField] private GameObject feedbackNegativo, feedbackPositivo;
    [SerializeField] private AudioSource source;
    [SerializeField] private GameObject[] bottomPieceOrder;
    [SerializeField] private GameObject[] topPieceOrder;
    [SerializeField] private GameObject[] shoesPieceOrder;
    private static int iVidaRestante = 5;

    private static GameObject _panelScore, _panelVida;
    private static GameObject _panelAcabouFase, _panelPerdeuFase, objRoupas;
    private static AudioSource _source;
    public static GameObject _feedbackNegativo, _feedbackPositivo;
    public static GameObject[] _shoesPieceOrder, _bottomPieceOrder, _topPieceOrder;
    private void Start()
    {
        _panelScore = panelScore;
        _panelVida = panelVida;
        _panelAcabouFase = panelAcabouFase;
        _panelPerdeuFase = panelPerdeuFase;
        _feedbackNegativo = feedbackNegativo;
        _feedbackPositivo = feedbackPositivo;
        _source = source;
        _shoesPieceOrder = shoesPieceOrder;
        _bottomPieceOrder = bottomPieceOrder;
        _topPieceOrder = topPieceOrder;

        objRoupas = _objRoupas; // Desculpe quebrar o padrão

        iVidaRestante = 5;
    }
    public void IniciarFase1()
    {
        ProgressionManager.zerarInteracao();
        ProgressionManager.controleProgressao = 1;
        ProgressionManager.marcaTodaFase1();
        ProgressionManager.marcaTodaFase2();
        ProgressionManager.ProximoNivelFase();
    }
    public void IniciarFase2()
    {
        ProgressionManager.zerarInteracao();
        ProgressionManager.controleProgressao = 2;
        ProgressionManager.marcaTodaFase2();
        ProgressionManager.ProximoNivelFase();
    }
    public void RefazerFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RefazerJogo()
    {
        ProgressionManager.zerarInteracao();
        IniciarFase1();
    }
    public void AvancarJogo()
    {
        ProgressionManager.ProximoNivelFase();
    }
    public void AbrirInstrucao()
    {
        string numFase = SceneManager.GetActiveScene().name.Split("Fase")[1];

        SceneManager.LoadScene("Instrucao" + numFase);
    }
    public void AbrirPanelSairFase()
    {
        if (_objSetas)
        {
            _objSetas.gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Contains("Fase2"))
        {
            _objRoupas.gameObject.SetActive(false);
        } else
        {
            for (var i = 0; i < _objRoupas.transform.childCount; i++)
                {
                    GameObject child = _objRoupas.transform.GetChild(i).gameObject;
                    GameObject bed = GameObject.Find("bed");
                    double distancia = Vector2.Distance(child.transform.position, bed.transform.position);

                    if (child.tag != "correct" || distancia > 4)  // Número arbitrário
                    {
                        child.gameObject.SetActive(false);
                    }
                }
        }

        panelSairFase.gameObject.SetActive(true);
    }
    public void FecharPanelSairFase()
    {
        panelSairFase.gameObject.SetActive(false);
        if (_objSetas)
        {
            _objSetas.gameObject.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name.Contains("Fase2"))
        {
            _objRoupas.gameObject.SetActive(true);
        }
        else
        {
            for (var i = 0; i < _objRoupas.transform.childCount; i++)
            {
                _objRoupas.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    public static IEnumerator checkFimFase()
    {
        yield return new WaitForSeconds(1f);

        bool acabou = true;
        for (var i = 0; i < _panelScore.transform.childCount / 2; i++)
        {
            GameObject childVerde = _panelScore.transform.Find("acertoVerde" + (i + 1).ToString()).gameObject;

            if (!childVerde.gameObject.activeSelf)
            {
                acabou = false;
                break;
            }
        }

        if (acabou)
        {
            if (!SceneManager.GetActiveScene().name.Contains("Fase2"))
            {
                escondeRoupas();
            } else
            {
                objRoupas.gameObject.SetActive(false);
            }

            _panelAcabouFase.gameObject.SetActive(true);
        }
    }
    public static void novoAcerto()
    {
        for (var i = 0; i < _panelScore.transform.childCount / 2; i++)
        {
            GameObject childCinza = _panelScore.transform.Find("acertoCinza" + (i + 1).ToString()).gameObject;
            GameObject childVerde = _panelScore.transform.Find("acertoVerde" + (i + 1).ToString()).gameObject;

            if (childCinza.gameObject.activeSelf)
            {
                childCinza.gameObject.SetActive(false);
                childVerde.gameObject.SetActive(true);
                break;
            }
        }
    }
    public static IEnumerator perdeVida()
    {
        iVidaRestante--;

        int index = _panelVida.transform.childCount;

        for (var i = 0; i < _panelVida.transform.childCount; i++)
        {
            GameObject child = _panelVida.transform.Find("vida" + (i + 1).ToString()).gameObject;

            if (!child.gameObject.activeSelf)
            {
                index = i;
                break;
            }
        }

        if (iVidaRestante == 0)
        {
            yield return new WaitForSeconds(1f);
            if (!SceneManager.GetActiveScene().name.Contains("Fase2"))
            {
                escondeRoupas();
            } else
            {
                objRoupas.gameObject.SetActive(false);
            }
            _panelPerdeuFase.gameObject.SetActive(true);
        } else
        {
            GameObject child = _panelVida.transform.Find("vida" + index.ToString()).gameObject;
            child.gameObject.SetActive(false);
        }
    }
    private static void escondeRoupas()
    {
        GameObject wardrobe = GameObject.Find("wardrobe").gameObject;

        for (var i = 0; i < wardrobe.transform.childCount; i++)
        {
            GameObject child = wardrobe.transform.GetChild(i).gameObject;

            child.gameObject.SetActive(false);
        }
    }
    public static void tocaClip(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
