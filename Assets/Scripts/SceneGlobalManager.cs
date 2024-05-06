using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGlobalManager : MonoBehaviour
{

    [SerializeField] private SO_ManagerScenes controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            controller.CargarScena.CallEventInt(1);
        }
        else if (Input.GetKeyDown("2"))
        {
            controller.CargarScena.CallEventInt(2);
            controller.DescargarEscena.CallEventInt(1);
        }
        else if (Input.GetKeyDown("3"))
        {
            controller.CargarScena.CallEventInt(3);
            controller.DescargarEscena.CallEventInt(2);
        }
        else if (Input.GetKeyDown("4"))
        {
            controller.CargarScena.CallEventInt(1);
            controller.DescargarEscena.CallEventInt(3);
        }
    }
}
