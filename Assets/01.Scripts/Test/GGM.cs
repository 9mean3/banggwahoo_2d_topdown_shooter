using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGM : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private Vector2 _destination;
    private Camera _mainCam;
    private Tween t = null;
    private SpriteRenderer _sr;

    [SerializeField]
    GameObject[] hearts;

    private void Awake()
    {
        hearts[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
        hearts[1].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
        hearts[2].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0);
        _sr = GetComponentInChildren<SpriteRenderer>();
        _sr.color = new Color(1f, 1f, 1f, 0);
    }

    void Start()
    {
        _mainCam = Camera.main;
        _destination = transform.position;
    }

    private void Update()
    {
        /*        if (Input.GetMouseButtonDown(0))
                {
                    _destination = _mainCam.ScreenToWorldPoint(Input.mousePosition);

                    _sr.DOFade(1f, 1f);


                    Sequence seq = DOTween.Sequence(); //new 아님
                    //seq.AppendInterval(1f);
                    seq.Append(transform.DOMove(_destination, 1f).SetEase(Ease.InBounce));
                    seq.Join(transform.DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360));
                    seq.AppendInterval(1f);
                    seq.AppendCallback(() =>
                    {
                        Debug.Log("완료");
                    });
                    //시퀀스는 스타트 없다 등록하면 담 프렘에서 바로 실행
                }*/
        //MoveToDestination();


        if (Input.GetMouseButtonDown(0))
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(hearts[0].transform.DOMove(new Vector3(hearts[0].transform.position.x, hearts[0].transform.position.y + 1), 1f));
            seq.Join(hearts[0].GetComponent<SpriteRenderer>().DOFade(1f, 1f));
            seq.AppendInterval(0.2f);
            seq.Append(hearts[1].transform.DOMove(new Vector3(hearts[1].transform.position.x, hearts[1].transform.position.y + 1), 1f));
            seq.Join(hearts[1].GetComponent<SpriteRenderer>().DOFade(1f, 1f));
            seq.AppendInterval(0.2f);
            seq.Append(hearts[2].transform.DOMove(new Vector3(hearts[2].transform.position.x, hearts[2].transform.position.y + 1), 1f));
            seq.Join(hearts[2].GetComponent<SpriteRenderer>().DOFade(1f, 1f));
            seq.AppendInterval(0.2f);

            for (int i = 0; i < 3; i++)
            {
                seq.Append(hearts[i].transform.DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360));

            }
        }
    }

    private void MoveToDestination()
    {
        Vector3 dir = (Vector3)_destination - transform.position;
        if (dir.magnitude > 0.1f)
        {
            transform.Translate(dir.normalized * Time.deltaTime * _speed);
        }
    }
}
