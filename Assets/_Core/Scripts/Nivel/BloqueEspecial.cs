using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BloqueEspecial : MonoBehaviour
{
    public BloqueType tipo;
    public SpriteRenderer sprite;
    public Sprite SpriteApagado;
    public Animator anim;
    public GameObject moneda;
    public bool active = true;

    private void OnCollisionEnter2D(Collision2D other) {
        if(!active) {return;}
        if(other.gameObject.tag != Constantes.TAG_PLAYER){ return; }
        if(GameManager.Instancia.player.playerMovement.estaEnSuelo){ return; }

        active=false;

        sprite.sprite = SpriteApagado;
        anim.Play("BloqueEspecialSalto");
        
        if(tipo == BloqueType.Monedas)
        {
            AnimarMoneda();
        }else if(tipo == BloqueType.Hongos)
        {

        }else if(tipo == BloqueType.FlorFuego)
        {

        }
    }

    public float monedaSaltoTime;
    public void AnimarMoneda()
    {
        GameManager.Instancia.AgregarMoneda();
        moneda.SetActive(true);
        moneda.transform.DOLocalMove(new Vector2(0, 2), monedaSaltoTime).OnComplete(MonedaOnComplete);
        //moneda.transform.DOLocalRotate(new Vector3(0,359,0), 0.3f).SetLoops(-1);
    }

    public void MonedaOnComplete()
    {
        moneda.transform.DOLocalMove(new Vector2(0, 0.5f), monedaSaltoTime).SetDelay(0.1f).OnComplete(() => moneda.SetActive(false));
    }
}

