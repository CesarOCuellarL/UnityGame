using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public int monedas;
    public int puntos;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI puntosText;
    public List<UI_Vida> vidasList;
    public Player player;

    void Start()
    {
        Instancia = this;
    }

    void Update()
    {
        
    }

    public void AgregarPuntos(int _puntos)
    {
        puntos += _puntos;
        puntosText.text = puntos.ToString();
        Debug.Log("Puntos: " + puntos);
    }

    public void AgregarMoneda()
    {
        monedas++;
        monedasText.text = "X " + monedas.ToString();
        Debug.Log("Monedas: " + monedas);
    }

    public void QuitarVida(int _vidas)
    {
        if(_vidas < 0){ return; }

        vidasList[_vidas].ApagarVida();
    }
}
