using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    [Header("Condiciones para 3 Estrellas")]
    [Range(0,1000)]
    public int puntosPara3Estrellas;
    [Range(0,3)]
    public int vidasPara3Estrellas;
    [Header("Condiciones para 2 Estrellas")]
    [Range(0,1000)]
    public int puntosPara2Estrellas;
    [Range(0,3)]
    public int vidasPara2Estrellas;
    void Start()
    {
        GameManager.Instancia.nivelActual = this;
    }

    public int CalcularEstrellas()
    {
        if(GameManager.Instancia.puntos >= puntosPara3Estrellas && GameManager.Instancia.player.vidas >= vidasPara3Estrellas)
        {
            return 3;
        }
        if(GameManager.Instancia.puntos >= puntosPara2Estrellas && GameManager.Instancia.player.vidas >= vidasPara2Estrellas)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

}
