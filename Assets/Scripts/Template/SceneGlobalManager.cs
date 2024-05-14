using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGlobalManager : MonoBehaviour
{

    [SerializeField] private SO_ManagerScenes controller;
    public HandleMessage muerte;
    void Start()
    {
        controller.CargarScena.CallEventInt(1);
    }
    private void OnEnable()
    {
        muerte.ActionGeneral += ChangeToMenu;

    }
    private void OnDisable()
    {
        muerte.ActionGeneral -= ChangeToMenu;

    }
    public void ChangeToScene(int sceneNumber)
    {
        controller.CargarScena.CallEventInt(sceneNumber);
    }
    public void ChangeToMenu()
    {
       
        controller.CargarScena.CallEventInt(1);
        controller.DescargarEscena.CallEventInt(2);
    }
}
