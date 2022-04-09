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
    public GameObject llave;
    public GameObject vida;
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
        }
        else if(tipo == BloqueType.Vida)
        {
            AnimarVida();
        }
        else if(tipo == BloqueType.Estrella)
        {

        }
        else if(tipo == BloqueType.Llave)
        {
            AnimarLlave();
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

    public float llaveSaltoTime;

    public void AnimarLlave()
    {
        GameManager.Instancia.AgregarLlave();
        llave.SetActive(true);
        llave.transform.DOLocalMove(new Vector2(0, 2), llaveSaltoTime).OnComplete(LlaveOnComplete);
    }

    public void LlaveOnComplete()
    {
        llave.transform.DOLocalMove(new Vector2(0, 0.5f), llaveSaltoTime).SetDelay(0.1f).OnComplete(() => llave.SetActive(false));
    }

    public float vidaSaltoTime;

    public void AnimarVida()
    {
        GameManager.Instancia.AgregarVida();
        vida.SetActive(true);
        vida.transform.DOLocalMove(new Vector2(0, 2), vidaSaltoTime).OnComplete(VidaOnComplete);
    }

    public void VidaOnComplete()
    {
        vida.transform.DOLocalMove(new Vector2(0, 0.5f), vidaSaltoTime).SetDelay(0.1f).OnComplete(() => vida.SetActive(false));
    }

}

