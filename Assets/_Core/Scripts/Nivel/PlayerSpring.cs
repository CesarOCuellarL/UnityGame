using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpring : MonoBehaviour
{
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != Constantes.TAG_PLAYER){ return; }
        if(GameManager.Instancia.player.playerMovement.rb.velocity.y <= 0 ){ 
            Debug.Log("Personaje Pisando");        
        }
    }
}
