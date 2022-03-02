using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int puntos;
    public bool sePuedePisar;
    [Space(30)]
    public SpriteRenderer spriteRenderer;
    public Sprite spriteBlanco;
    public Animator anim;
    public BoxCollider2D boxCollider2D;

    public void HacerDaño(){
        GameManager.Instancia.AgregarPuntos(puntos);

        anim.enabled = false;
        boxCollider2D.enabled = false;
        spriteRenderer.sprite = spriteBlanco;

        Invoke("ApagarEnemigo", 0.4f);
    }
    private void ApagarEnemigo(){
        gameObject.SetActive(false);

    }   
}
