using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaObjetivo : MonoBehaviour
{
    public GameObject lootUIPos;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;
    public Sprite spritetop;
    public Sprite spritedown;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && GameManager.Instancia.tieneLlave == true)
        {
            RealizarAccion();
        }      
    }

    public void RealizarAccion()
    {
        spriteRenderer.sprite = spritedown;
        spriteRenderer2.sprite = spritetop;
        GameManager.Instancia.CambioPuerta = true; 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != Constantes.TAG_PLAYER){ return; }
        GameManager.Instancia.lootUIPuerta.transform.position = lootUIPos.transform.position;
        GameManager.Instancia.lootUIPuerta.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag != Constantes.TAG_PLAYER){ return; }     
        GameManager.Instancia.lootUIPuerta.SetActive(false);
    }
}
