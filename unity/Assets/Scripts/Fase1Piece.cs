using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase1Piece : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _flechaGuia, _flechaRoupa;

    private bool _dragging, _placed;
    private Vector2 _offset;
    private Vector3 _originalPosition;

    private void Awake()
    {
        _originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (_placed) return;
        if (!_dragging) return;

        Vector2 mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;

        transform.position = new Vector3(transform.position.x, transform.position.y, -2);
    }

    private void OnMouseDown()
    {
        if (_placed) return;

        _dragging = true;
        FasesManager.tocaClip(SoundManager.pickUp);

        _offset = GetMousePos() - (Vector2)transform.position;

        if (_flechaGuia != null)
        {
            _flechaGuia.gameObject.SetActive(true);
            _flechaRoupa.gameObject.SetActive(false);
        }
    }

    private void OnMouseUp()
    {
        if (_placed) return;
        if (!_dragging) return;

        if (Vector2.Distance(transform.position, _target.transform.position) < 2.8)  // 2.8 é um número escolhido arbitrariamente
        {
            bool put = false;

            if (tag.Equals("correct"))
            {
                putPiece();
                put = true;
            }

            if (!put)
            {
                _dragging = false;
                transform.localPosition = _originalPosition;
                wrongAction();
            }
        }
        else
        {
            _dragging = false;
            transform.localPosition = _originalPosition;
            FasesManager.tocaClip(SoundManager.drop);

            if (_flechaRoupa != null)
            {
                _flechaRoupa.gameObject.SetActive(true);
            }
        }

        if (_flechaGuia != null)
        {
            _flechaGuia.gameObject.SetActive(false);
        }
    }

    private void putPiece()
    {
        for (var i = 0; i < _target.transform.childCount; i++)
        {
            var child = _target.transform.GetChild(i);
            if (child.tag.Equals("empty"))
            {
                transform.position = child.transform.position;
                transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                child.tag = "full";
                break;
            }
        }

        _placed = true;

        feedbackPositivo();

        FasesManager.novoAcerto();
        StartCoroutine(FasesManager.checkFimFase());
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void wrongAction()
    {
        FasesManager.tocaClip(SoundManager.feedbackNegativo);

        feedbackNegativo();

        if (SceneManager.GetActiveScene().name != "Fase1.1")
        {
            StartCoroutine(FasesManager.perdeVida());
        }
    }

    private IEnumerator WaitFeedbackNegativo()
    {
        yield return new WaitForSeconds(1f);
        FasesManager._feedbackNegativo.gameObject.SetActive(false);
    }

    private void feedbackNegativo()
    {
        FasesManager._feedbackNegativo.gameObject.SetActive(true);
        StartCoroutine(WaitFeedbackNegativo());
    }

    private IEnumerator WaitFeedbackPositivo()
    {
        yield return new WaitForSeconds(1f);
        FasesManager._feedbackPositivo.gameObject.SetActive(false);
    }

    private void feedbackPositivo()
    {
        FasesManager.tocaClip(SoundManager.feedbackPositivo);
        FasesManager._feedbackPositivo.gameObject.SetActive(true);
        StartCoroutine(WaitFeedbackPositivo());
    }
}
