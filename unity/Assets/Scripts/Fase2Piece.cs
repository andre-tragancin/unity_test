using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase2Piece : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _flechaGuia, _flechaRoupa;

    private bool _dragging, _placed;
    private Vector2 _offset;
    private Vector3 _originalPosition;

    //Get camera's MonoBehaviour
    private MonoBehaviour _objectMono;

    private void Start()
    {
        _objectMono = GameObject.Find("bed").GetComponent<MonoBehaviour>();
    }

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

        if (Vector2.Distance(transform.position, _target.transform.position) < 2.4)  // 2.4 é um número escolhido arbitrariamente
        {
            bool put = false;

            switch (transform.tag)
            {
                case "top":
                    if (transform.name == FasesManager._topPieceOrder[0].name)
                    {
                        put = true;
                        FasesManager._topPieceOrder = FasesManager._topPieceOrder.Skip(1).ToArray();
                    }

                    break;
                case "bottom":
                    if (transform.name == FasesManager._bottomPieceOrder[0].name)
                    {
                        put = true;
                        FasesManager._bottomPieceOrder = FasesManager._bottomPieceOrder.Skip(1).ToArray();
                    }

                    break;
                case "feet":
                    if (transform.name == FasesManager._shoesPieceOrder[0].name)
                    {
                        if (FasesManager._shoesPieceOrder.Length > 1 || FasesManager._bottomPieceOrder.Length == 0)
                        {
                            put = true;
                            FasesManager._shoesPieceOrder = FasesManager._shoesPieceOrder.Skip(1).ToArray();
                        }
                    }

                    break;
            }

            if (put) 
            {
                putPiece();
            } else
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
            if (child.name == transform.name)
            {
                transform.gameObject.SetActive(false);
                transform.localPosition = _originalPosition;
                child.gameObject.SetActive(true);
                break;
            }
        }

        _placed = true;

        feedbackPositivo();

        FasesManager.novoAcerto();
        _objectMono.StartCoroutine(FasesManager.checkFimFase());
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void wrongAction()
    {
        FasesManager.tocaClip(SoundManager.feedbackNegativo);

        feedbackNegativo();

        if (SceneManager.GetActiveScene().name != "Fase2.1")
        {
            _objectMono.StartCoroutine(FasesManager.perdeVida());
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
        _objectMono.StartCoroutine(WaitFeedbackNegativo());
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
        _objectMono.StartCoroutine(WaitFeedbackPositivo());
    }
}
