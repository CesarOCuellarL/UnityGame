using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoverObjeto : MonoBehaviour
{
    public float tiempo;

    [Space(30)]
    public GameObject PosicionInicial;
    public GameObject PosicionFinal;

    [Space(30)]
    public GameObject objetoMover;
    void Start()
    {
        objetoMover.transform.position = PosicionInicial.transform.position;
        objetoMover.transform.DOMove(PosicionFinal.transform.position, tiempo).SetLoops(-1, LoopType.Yoyo);   
    }


}
