using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public Rigidbody2D rigidbody2D;
    public int velocidad;
    
    void Start()
    {
        rigidbody2D.velocity = new Vector2(velocidad,0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
       if(other.tag != Constantes.TAG_ESCENARIO) { return; }

        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * -1,0);
        transform.Rotate(0,180,0);
    }
}
