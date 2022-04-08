using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instancia;
    public GameObject loadingMenu; 
    
    public int nivelActual = 1;
    
    void Start()
    { 
        Instancia= this;

        SceneManager.sceneUnloaded += TerminoDeQuitarEscena;
        SceneManager.sceneLoaded += TerminoDeCargarEscena;
    }

    public void Retry()
    {
        loadingMenu.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
    }

    public void SiguienteNivel()
    {
        loadingMenu.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual++;
    }

    public void CargarNivel(int _nivel)
    {
        loadingMenu.SetActive(true);
        
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual = _nivel;

    }

    private void TerminoDeQuitarEscena(Scene scene)
    {
        SceneManager.LoadScene("Nivel_" + nivelActual, LoadSceneMode.Additive);
    }
    private void TerminoDeCargarEscena(Scene scene, LoadSceneMode mode)
    {
        loadingMenu.SetActive(false);
        GameManager.Instancia.IniciaSiguienteNivel();
    }
}
