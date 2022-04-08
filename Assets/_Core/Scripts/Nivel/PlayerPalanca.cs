using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPalanca : MonoBehaviour
{
    public GameObject lootUIPos;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    public GameObject objeto;

    private bool isActive = false;

    void Update()
    {
        if(!isActive){ return; }
        if(Input.GetKeyDown(KeyCode.H))
        {
            RealizarAccion();
        }
    }

    private void RealizarAccion()
    {
        spriteRenderer.sprite = sprite;
        objeto.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != Constantes.TAG_PLAYER){ return; }

        isActive = true;

        GameManager.Instancia.lootUIPalanca.transform.position = lootUIPos.transform.position;
        GameManager.Instancia.lootUIPalanca.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag != Constantes.TAG_PLAYER){ return; }

        isActive = false;
        
        GameManager.Instancia.lootUIPalanca.SetActive(false); 
    }
}
