using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public Player player;
    public Nivel nivelActual;
    public int monedas;
    public int puntos;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI puntosText;
    public List<UI_Vida> vidasList;

    public GameObject gameOverMenu; 
    public GameObject nivelCompletadoMenu; 
    public GameObject lootUI;
    public GameObject lootUIPalanca;
    public GameObject lootUIPuerta;
    public Button pauseButton;
    public GameObject seleccionDeNivelMenu;

     [Header("Llave")]
    public bool tieneLlave = false;
    public GameObject Llave;
    public bool CambioPuerta = false;

    [Header("Vidas")]
    public int vidas = 0;

    void Start()
    {
        Instancia = this;

        pauseButton.onClick.AddListener(ShowLevelSelect);
    }

    public void ShowLevelSelect()
    {
        seleccionDeNivelMenu.SetActive(true);
    }

    void Update()
    {

    }
    
    public void IniciaSiguienteNivel()
    {
        onGameReset();
    }

    public void Retry()
    {
        onGameReset();
        LevelManager.Instancia.Retry();
    }

    public void GameOver()
    {
        player.playerMovement.BloquearMovimiento();
        AudioManager.Instancia.PlayAudio(AudioManager.AUDIO_GAMEOVER);
        gameOverMenu.SetActive(true);
    }
    
    public void NivelCompletado()
    {
        player.playerMovement.BloquearMovimiento();
        AudioManager.Instancia.PlayAudio(AudioManager.AUDIO_NIVELCOMPLETADO);
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
        AudioManager.Instancia.PlayAudio(AudioManager.AUDIO_MONEDA);
        monedas++;
        monedasText.text = "X " + monedas.ToString();
        Debug.Log("Monedas: " + monedas);
    }

    public void AgregarLlave()
    {      
        AudioManager.Instancia.PlayAudio(AudioManager.AUDIO_MONEDA);
        Llave.GetComponent<Animator>().Play("Llave");
        tieneLlave = true;
    }

     public void AgregarVida()
    {
        if(vidas > 2){ return; }      
        AudioManager.Instancia.PlayAudio(AudioManager.AUDIO_MONEDA);
        vidasList[vidas].PrenderVida();
        vidas++;
        player.vidas = vidas;
    }

    public void QuitarVida(int _vidas)
    {
        if(_vidas < 0){ return; }

        vidas = _vidas;
        vidasList[_vidas].ApagarVida();
    }

    public void onGameReset()
    {
        player.ResetPlayer();

        foreach(var vida in vidasList)
        {
            vida.PrenderVida();
        }

        monedas = 0;
        monedasText.text = "X " + monedas.ToString();

        puntos = 0;
        puntosText.text = "00000";

    }
}
