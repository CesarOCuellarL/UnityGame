using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public Player player;
    public int monedas;
    public int puntos;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI puntosText;
    public List<UI_Vida> vidasList;

    public GameObject gameOverMenu; 
    public GameObject nivelCompletadoMenu; 
    void Start()
    {
        Instancia = this;
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        player.playerMovement.BloquearMovimiento();
        gameOverMenu.SetActive(true);
    }
    
    public void NivelCompletado()
    {
        player.playerMovement.BloquearMovimiento();
        nivelCompletadoMenu.SetActive(true);
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
