using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "SO_ManagerScenes", menuName = "ScriptableObject/SO_ManagerScenes/Manager")]
public class SO_ManagerScenes : ScriptableObject
{
    //public string SeceneNextName;
    public HandleMessage DescargarEscena;
    public HandleMessage ActionInt;
    public HandleMessage CargarScena;

    private void OnEnable()
    {
        //Esta solo sirve para cuando se cargar escena y bota el modo de carga, no se para q usarlo
        SceneManager.sceneLoaded += OnSceneLoaded;
        //Esta solo me dice si una escena se quita
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        //////////////////////////////////////////////////////////////////////
        DescargarEscena.ActionGeneralInt += UnloadScene;
        CargarScena.ActionGeneralInt += LoadScene;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Se cargó una nueva escena.");
        Debug.Log("Nombre de la escena: " + scene.name);
        Debug.Log("Modo de carga: " + mode);

    }
    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("Se descargó una escena.");
        Debug.Log("Nombre de la escena: " + scene.name);
    }
    public void LoadScene(int SeceneNext)
    {
        SceneManager.LoadSceneAsync(SeceneNext, LoadSceneMode.Additive);
    }
    public void LoadScene(string SeceneInitName)
    {
        SceneManager.LoadSceneAsync(SeceneInitName, LoadSceneMode.Additive);
    }
    public void UnloadScene(int SeceneInit)
    {
        SceneManager.UnloadSceneAsync(SeceneInit);
    }
    public void UnloadScene(string SeceneInitName)
    {
        SceneManager.UnloadSceneAsync(SeceneInitName);
    }
    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);

    }
    private void OnDisable()
    {
        //Esta solo sirve para cuando se cargar escena y bota el modo de carga, no se para q usarlo
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //Esta solo me dice si una escena se quita
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}
