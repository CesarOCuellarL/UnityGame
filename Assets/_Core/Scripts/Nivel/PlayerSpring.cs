using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpring : MonoBehaviour
{
    public Animator anim; 
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != Constantes.TAG_PLAYER){ return; }
            GameManager.Instancia.player.playerMovement.rb.AddForce(new Vector2(500, 900));
            anim.Play("Trampolin");      
    }
}
