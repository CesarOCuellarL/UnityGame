using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public ParticleSystem particulas;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D collider;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != Constantes.TAG_PLAYER){ return; }
        if(GameManager.Instancia.player.playerMovement.estaEnSuelo){ return; }
        particulas.Play();
        //gameObject.SetActive(false);
        spriteRenderer.enabled=false;
        collider.enabled = false;
    }
}
