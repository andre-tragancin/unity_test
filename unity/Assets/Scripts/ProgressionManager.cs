using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour
{
    // Esse é um código que precisa de uma refatoração

    public static List<string> situacoesFase1Original = new List<string>();
    public static List<string> situacoesFase2Original = new List<string>();

    // 1 - por fase
    // 2 - por situacao
    public static int controleProgressao = -1;
    public static int faseAtual = -1;

    public static bool f1Marcado = false;
    public static bool f2Marcado = false;

    public static bool ultimaSituacao = false;
    public static bool primeiraSituacao = true;

    public GameObject CheckFase;
    public GameObject CheckSituacao;

    public GameObject Check11; // Dormir
    public GameObject Check12; // Escola quente
    public GameObject Check13; // Escola frio
    public GameObject Check14; // Fantasia
    public GameObject Check15; // Parque
    public GameObject Check16; // Passeio
    public GameObject Check17; // Professor
    public GameObject Check18; // Mercado

    public GameObject Check21; // Dormir
    public GameObject Check22; // Escola quente
    public GameObject Check23; // Escola frio
    public GameObject Check24; // Fantasia
    public GameObject Check25; // Parque
    public GameObject Check26; // Passeio
    public GameObject Check27; // Professor
    public GameObject Check28; // Mercado

    public GameObject setaProgressaoFase, setaProgressaoSituacao;
    public GameObject setaFase1, setaFase2, feedbackNegativo;

    public AudioSource audioSource;

    void Start()
    {
        zerarInteracao();
        uncheckAll();
        primeiraSituacao = true;
    }

    public void botaoClicado(string botao)
    {
        int fase = int.Parse(botao[0] + "");
        int situacao = int.Parse(botao[1] + "");
        string newFase = "Fase" + fase.ToString() + "." + situacao.ToString();
        bool marcacao;

        if (fase == 1)
        {
            if (situacoesFase1Original.Contains(newFase))
            {
                situacoesFase1Original.Remove(newFase);

                marcacao = false;
            } else
            {
                situacoesFase1Original.Add(newFase);

                situacoesFase1Original.Sort();

                marcacao = true;
            }

            switch (situacao)
            {
                case 1:
                    Check11.gameObject.SetActive(marcacao);
                    break;
                case 2:
                    Check12.gameObject.SetActive(marcacao);
                    break;
                case 3:
                    Check13.gameObject.SetActive(marcacao);
                    break;
                case 4:
                    Check14.gameObject.SetActive(marcacao);
                    break;
                case 5:
                    Check15.gameObject.SetActive(marcacao);
                    break;
                case 6:
                    Check16.gameObject.SetActive(marcacao);
                    break;
                case 7:
                    Check17.gameObject.SetActive(marcacao);
                    break;
                case 8:
                    Check18.gameObject.SetActive(marcacao);
                    break;
            }
        } else
        {
            if (situacoesFase2Original.Contains(newFase))
            {
                situacoesFase2Original.Remove(newFase);

                marcacao = false;
            }
            else
            {
                situacoesFase2Original.Add(newFase);
                situacoesFase2Original.Sort();

                marcacao = true;
            }

            switch (situacao)
            {
                case 1:
                    Check21.gameObject.SetActive(marcacao);
                    break;
                case 2:
                    Check22.gameObject.SetActive(marcacao);
                    break;
                case 3:
                    Check23.gameObject.SetActive(marcacao);
                    break;
                case 4:
                    Check24.gameObject.SetActive(marcacao);
                    break;
                case 5:
                    Check25.gameObject.SetActive(marcacao);
                    break;
                case 6:
                    Check26.gameObject.SetActive(marcacao);
                    break;
                case 7:
                    Check27.gameObject.SetActive(marcacao);
                    break;
                case 8:
                    Check28.gameObject.SetActive(marcacao);
                    break;
            }
        }
    }
    public static void marcaTodaFase1()
    {
        string situacao;

        if (f1Marcado)
        {
            situacoesFase1Original = new List<string>();

            f1Marcado = false;
        } else
        {
            for (int i = 1; i <= 8; i++)
            {
                situacao = "Fase1." + i.ToString();
                situacoesFase1Original.Add(situacao);
            }

            f1Marcado = true;
        }
    }
    public static void marcaTodaFase2()
    {
        string situacao;

        if (f2Marcado)
        {
            situacoesFase2Original = new List<string>();

            f2Marcado = false;
        }
        else
        {
            for (int i = 1; i <= 8; i++)
            {
                situacao = "Fase2." + i.ToString();
                situacoesFase2Original.Add(situacao);
            }

            f2Marcado = true;
        }
    }
    public void checkTodaFase1()
    {
        marcaTodaFase1();

        Check11.gameObject.SetActive(f1Marcado);
        Check12.gameObject.SetActive(f1Marcado);
        Check13.gameObject.SetActive(f1Marcado);
        Check14.gameObject.SetActive(f1Marcado);
        Check15.gameObject.SetActive(f1Marcado);
        Check16.gameObject.SetActive(f1Marcado);
        Check17.gameObject.SetActive(f1Marcado);
        Check18.gameObject.SetActive(f1Marcado);
    }
    public void checkTodaFase2()
    {
        marcaTodaFase2();

        Check21.gameObject.SetActive(f2Marcado);
        Check22.gameObject.SetActive(f2Marcado);
        Check23.gameObject.SetActive(f2Marcado);
        Check24.gameObject.SetActive(f2Marcado);
        Check25.gameObject.SetActive(f2Marcado);
        Check26.gameObject.SetActive(f2Marcado);
        Check27.gameObject.SetActive(f2Marcado);
        Check28.gameObject.SetActive(f2Marcado);
    }
    public void progredirFase()
    {
        if (CheckFase.activeSelf)
        {
            controleProgressao = -1;
            CheckFase.gameObject.SetActive(false);
        } else
        {
            controleProgressao = 1;
            CheckFase.gameObject.SetActive(true);
        }

        if (CheckSituacao.activeSelf)
        {
            CheckSituacao.gameObject.SetActive(false);
        }
    }
    public void progredirSituacao()
    {
        if (CheckSituacao.activeSelf)
        {
            controleProgressao = -1;
            CheckSituacao.gameObject.SetActive(false);
        }
        else
        {
            controleProgressao = 2;
            CheckSituacao.gameObject.SetActive(true);
        }

        if (CheckFase.activeSelf)
        {
            CheckFase.gameObject.SetActive(false);
        }
    }
    public static void zerarInteracao()
    {
        situacoesFase1Original = new List<string>();
        situacoesFase2Original = new List<string>();

        controleProgressao = -1;
        faseAtual = 1;
        ultimaSituacao = false;
        f1Marcado = false;
        f2Marcado = false;
        primeiraSituacao = true;
;    }
    public void uncheckAll()
    {
        CheckFase.gameObject.SetActive(false);
        CheckSituacao.gameObject.SetActive(false);

        Check11.gameObject.SetActive(false);
        Check12.gameObject.SetActive(false);
        Check13.gameObject.SetActive(false);
        Check14.gameObject.SetActive(false);
        Check15.gameObject.SetActive(false);
        Check16.gameObject.SetActive(false);
        Check17.gameObject.SetActive(false);
        Check18.gameObject.SetActive(false);

        Check21.gameObject.SetActive(false);
        Check22.gameObject.SetActive(false);
        Check23.gameObject.SetActive(false);
        Check24.gameObject.SetActive(false);
        Check25.gameObject.SetActive(false);
        Check26.gameObject.SetActive(false);
        Check27.gameObject.SetActive(false);
        Check28.gameObject.SetActive(false);
    }
    public static void ProximoNivelFase()
    {
        string nomeFase = "";

        if (!ultimaSituacao)
        {
            if (controleProgressao == 1)
            {
                if (faseAtual == -1)
                {
                    faseAtual = 1;
                }

                if (faseAtual == 1)
                {
                    if (situacoesFase1Original.Count != 0)
                    {
                        nomeFase = situacoesFase1Original[0];
                        situacoesFase1Original.Remove(situacoesFase1Original[0]);

                        if (situacoesFase1Original.Count == 0 && situacoesFase2Original.Count == 0)
                        {
                            ultimaSituacao = true;
                        }
                    }
                    else
                    {
                        faseAtual = 2;
                        nomeFase = situacoesFase2Original[0];
                        situacoesFase2Original.Remove(situacoesFase2Original[0]);

                        if (situacoesFase2Original.Count == 0)
                        {
                            ultimaSituacao = true;
                        }
                    }

                }
                else
                {
                    nomeFase = situacoesFase2Original[0];
                    situacoesFase2Original.Remove(situacoesFase2Original[0]);

                    if (situacoesFase2Original.Count == 0)
                    {
                        ultimaSituacao = true;
                    }

                }
            }
            else
            {
                string[] faseArray;
                string sSituacao = "";
                int iSituacao = 0;

                if (faseAtual == -1 || primeiraSituacao)
                {
                    faseAtual = 2;
                    primeiraSituacao = false;
                }
                else
                {
                    faseArray = SceneManager.GetActiveScene().name.Split(".");
                    sSituacao = faseArray[1];
                    iSituacao = int.Parse(sSituacao);
                }

                if (faseAtual == 1)
                {
                    if (situacoesFase2Original.Count > 0)
                    {
                        if (situacoesFase2Original[0] == "Fase2." + sSituacao)
                        {
                            faseAtual = 2;
                            nomeFase = situacoesFase2Original[0];
                            situacoesFase2Original.Remove(situacoesFase2Original[0]);

                            if (situacoesFase1Original.Count == 0 && situacoesFase2Original.Count == 0)
                            {
                                ultimaSituacao = true;
                            }
                        }
                        else
                        {
                            if (situacoesFase1Original.Count > 0)
                            {
                                int novaFase1 = int.Parse(situacoesFase1Original[0].Split(".")[1]);
                                int novaFase2 = int.Parse(situacoesFase1Original[0].Split(".")[1]);

                                if (novaFase1 < novaFase2)
                                {
                                    nomeFase = situacoesFase1Original[0];
                                    situacoesFase1Original.Remove(situacoesFase1Original[0]);
                                }
                                else
                                {
                                    faseAtual = 2;
                                    nomeFase = situacoesFase2Original[0];
                                    situacoesFase2Original.Remove(situacoesFase2Original[0]);
                                }
                            }
                            else
                            {
                                faseAtual = 2;
                                nomeFase = situacoesFase2Original[0];
                                situacoesFase2Original.Remove(situacoesFase2Original[0]);

                                if (situacoesFase1Original.Count == 0 && situacoesFase2Original.Count == 0)
                                {
                                    ultimaSituacao = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        nomeFase = situacoesFase1Original[0];
                        situacoesFase1Original.Remove(situacoesFase1Original[0]);

                        if (situacoesFase1Original.Count == 0)
                        {
                            ultimaSituacao = true;
                        }
                    }
                }
                else
                {
                    if (situacoesFase1Original.Count > 0)
                    {
                        if (int.Parse(situacoesFase1Original[0].Split(".")[1]) == iSituacao + 1)
                        {
                            faseAtual = 1;
                            nomeFase = situacoesFase1Original[0];
                            situacoesFase1Original.Remove(situacoesFase1Original[0]);
                        }
                        else
                        {
                            if (situacoesFase2Original.Count > 0)
                            {
                                int novaFase1 = int.Parse(situacoesFase1Original[0].Split(".")[1]);
                                int novaFase2 = int.Parse(situacoesFase2Original[0].Split(".")[1]);

                                if (novaFase1 <= novaFase2)
                                {
                                    faseAtual = 1;
                                    nomeFase = situacoesFase1Original[0];
                                    situacoesFase1Original.Remove(situacoesFase1Original[0]);
                                }
                                else
                                {
                                    nomeFase = situacoesFase2Original[0];
                                    situacoesFase2Original.Remove(situacoesFase2Original[0]);
                                }
                            }
                            else
                            {
                                faseAtual = 1;
                                nomeFase = situacoesFase1Original[0];
                                situacoesFase1Original.Remove(situacoesFase1Original[0]);

                                if (situacoesFase1Original.Count == 0 && situacoesFase2Original.Count == 0)
                                {
                                    ultimaSituacao = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        nomeFase = situacoesFase2Original[0];
                        situacoesFase2Original.Remove(situacoesFase2Original[0]);

                        if (situacoesFase2Original.Count == 0)
                        {
                            ultimaSituacao = true;
                        }
                    }
                }
            }
        }
        
        if (nomeFase == "")
        {
            nomeFase = "MapaFases";
        }

        SceneManager.LoadScene(nomeFase);
    }

    public void IniciarJogo()
    {
        if (controleProgressao == -1)
        {
            feedbackNegativoProgressao();
        } else
        {
            if (situacoesFase1Original.Count == 0 && situacoesFase2Original.Count == 0)
            {
                feedbackNegativoFase();
            } else
            {
                ProximoNivelFase();
            }
        }
    }

    private IEnumerator WaitFeedbackNegativoProgressao()
    {
        yield return new WaitForSeconds(1f);
        setaProgressaoFase.gameObject.SetActive(false);
        setaProgressaoSituacao.gameObject.SetActive(false);
        feedbackNegativo.gameObject.SetActive(false);
    }

    private void feedbackNegativoProgressao()
    {
        audioSource.PlayOneShot(SoundManager.feedbackNegativo);
        setaProgressaoFase.gameObject.SetActive(true);
        setaProgressaoSituacao.gameObject.SetActive(true);
        feedbackNegativo.gameObject.SetActive(true);
        StartCoroutine(WaitFeedbackNegativoProgressao());
    }

    private IEnumerator WaitFeedbackNegativoFase()
    {
        yield return new WaitForSeconds(1f);
        setaFase1.gameObject.SetActive(false);
        setaFase2.gameObject.SetActive(false);
        feedbackNegativo.gameObject.SetActive(false);
    }

    private void feedbackNegativoFase()
    {
        audioSource.PlayOneShot(SoundManager.feedbackNegativo);
        setaFase1.gameObject.SetActive(true);
        setaFase2.gameObject.SetActive(true);
        feedbackNegativo.gameObject.SetActive(true);
        StartCoroutine(WaitFeedbackNegativoFase());
    }
}
