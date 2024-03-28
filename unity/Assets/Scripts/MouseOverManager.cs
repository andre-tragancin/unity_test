using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverManager : MonoBehaviour
{
    public GameObject fase1Helper, fase2Helper;
    public GameObject progredirSituacaoHelper, progredirFaseHelper;

    public void mostrarFase1Helper()
    {
        fase1Helper.gameObject.SetActive(true);
    }

    public void mostrarFase2Helper()
    {
        fase2Helper.gameObject.SetActive(true);
    }

    public void mostrarProgredirFaseHelper()
    {
        progredirFaseHelper.gameObject.SetActive(true);
    }

    public void mostrarProgredirSituacaoHelper()
    {
        progredirSituacaoHelper.gameObject.SetActive(true);
    }

    public void esconderFase1Helper()
    {
        fase1Helper.gameObject.SetActive(false);
    }

    public void esconderFase2Helper()
    {
        fase2Helper.gameObject.SetActive(false);
    }

    public void esconderProgredirFaseHelper()
    {
        progredirFaseHelper.gameObject.SetActive(false);
    }

    public void esconderProgredirSituacaoHelper()
    {
        progredirSituacaoHelper.gameObject.SetActive(false);
    }
}
