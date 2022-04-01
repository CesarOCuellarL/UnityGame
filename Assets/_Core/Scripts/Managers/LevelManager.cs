using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instancia;
    public GameObject loadingMenu; 
    void Start()
    { 
        Instancia= this;

        SceneManager.sceneUnloaded += TerminoDeQuitarEscena;
        SceneManager.sceneLoaded += TerminoDeCargarEscena;
    }
    public int nivelActual = 1;
    public void SiguienteNivel()
    {
        loadingMenu.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual++;
    }

    private void TerminoDeQuitarEscena(Scene scene)
    {
        SceneManager.LoadScene("Nivel_" + nivelActual, LoadSceneMode.Additive);
    }
    private void TerminoDeCargarEscena(Scene scene, LoadSceneMode mode)
    {
        loadingMenu.SetActive(false);
    }
}
