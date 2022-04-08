using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas_Manager : MonoBehaviour
{
    public static Particulas_Manager Instancia;
    public GameObject particulasObj;
    public GameObject bomba;

    void Start() {
        Instancia= this; 
    }

    public void LlevarParticula(Vector2 position)
    {
        Instantiate(particulasObj, position, Quaternion.identity);        
    }
}
