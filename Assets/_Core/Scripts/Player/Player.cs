using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteBlanco;
    public Sprite spriteTriste;

    public Animator anim;

    private int vidas = 3;
    private bool esInmune = false;

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Colision con:"+ other.name); 
        if(other.tag == Constantes.TAG_MONEDA)
        {
            AgarrarMoneda(other);
            
        }else if(other.tag == Constantes.TAG_ENEMIGO){
            Debug.Log("Enemigo!!!");
            if(other.GetComponent<Enemy>().sePuedePisar && playerMovement.rb.velocity.y < 0 && !esInmune)
            {
                ChecarEnemigo(other);
            }
            else if(!esInmune){
                HacerDaño();
            }
        }else if(other.tag == Constantes.TAG_PUERTA){
            //NIVEL COMPLETADO
            Debug.Log("Nivel Completado!");
        }
        else if(other.tag == Constantes.TAG_BARRANCO){
            //NIVEL COMPLETADO
            Debug.Log("Game Over");
        }
    }
    public void AgarrarMoneda(Collider2D other)
    {
        other.gameObject.SetActive(false);
        GameManager.Instancia.AgregarMoneda();    
    }

    public void ChecarEnemigo(Collider2D other)
    {
        other.GetComponent<Enemy>().HacerDaño();
        playerMovement.rb.velocity = Vector2.zero;
        playerMovement.rb.AddForce(new Vector2(0, 330));
    }

    public void HacerDaño()
    {
        esInmune = true;
        vidas--;

        GameManager.Instancia.QuitarVida(vidas);

        if(vidas <=0)
        {
            //murio 
        }
        

        playerMovement.bloquearMovimiento = true;
        playerMovement.rb.velocity = Vector2.zero;
        
        anim.enabled = false;
        spriteRenderer.sprite = spriteBlanco;
        
        if(playerMovement.estaVolteandoADerecha){
            playerMovement.rb.AddForce(new Vector2(-70, 330));
        }else{
            playerMovement.rb.AddForce(new Vector2(70, 330));
        }
        
        InvokeRepeating("Parpadeo", 0, 0.1f);
        Invoke("QuitarSpriteBlanco", 0.4f);

        Invoke("RegresoNormalidad",1);
    }

    private void Parpadeo()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    private void QuitarSpriteBlanco()
    {
        spriteRenderer.sprite = spriteTriste;
    }

    private void RegresoNormalidad()
    {
        esInmune = false;

        spriteRenderer.enabled = true;

        playerMovement.rb.velocity = Vector2.zero;
        playerMovement.bloquearMovimiento = false;
        CancelInvoke("Parpadeo");

        anim.enabled = true;
    }
}
