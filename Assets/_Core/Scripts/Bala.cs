using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        if(GameManager.Instancia.player.playerMovement.estaVolteandoADerecha)
        {
            rb.AddForce(new Vector2(150, 300));
        }else{
            rb.AddForce(new Vector2(-150, 300));
        }

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag != Constantes.TAG_PLAYER && other.gameObject.tag != Constantes.TAG_CAMARA){
            Particulas_Manager.Instancia.LlevarParticula(transform.position);
            if(other.gameObject.tag == Constantes.TAG_ENEMIGO)
            {
                if(!GameManager.Instancia.player.esInmune){
                    ChecarEnemigo(other);
                }
            }
            gameObject.SetActive(false);         
            Destroy(gameObject,.3f);
  
        }
    }

    public void ChecarEnemigo(Collider2D other)
    {
        other.GetComponent<Enemy>().HacerDaño();
    }

}
