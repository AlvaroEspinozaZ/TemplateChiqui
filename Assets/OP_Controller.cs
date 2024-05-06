using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Controller : MonoBehaviour
{
    [SerializeField] public SO_ObjectPooling Dinamic;
    [SerializeField] public SO_ObjectPooling Static;
    public int idD = 0;
    public int idS = 0;
    public int balasUsedDinamic = 0;
    public int balasUsedStatic = 0;
    void Start()
    {
        balasUsedDinamic = Dinamic.objectsInScene.Count;
        balasUsedStatic = Static.objectsInScene.Count;
        Dinamic.CreateOP();
        Static.CreateOP();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            HideObjectsStatic();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            HideObjectsDinamic();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            foreach(GameObject obj in Static.objectsInScene)
            {
                obj.SetActive(true); 
            }
            foreach (GameObject obj in Dinamic.objectsInScene)
            {
                obj.SetActive(true);
            }
        }
    }
    public void HideObjectsDinamic()
    {
        Dinamic.objectsInScene[idD].SetActive(false);
        Vector3 posInit = new Vector3(0, 0,1);
        Dinamic.objectsInScene[idD].transform.position = transform.position + posInit;
        idD = (idD + 1) % (Dinamic.objectsInScene.Count);
        balasUsedDinamic--;
        if (balasUsedDinamic < 0)
        {           
            Dinamic.objectsInScene.Add(Dinamic.GetObjectFromPool());
            balasUsedDinamic++;
            Debug.Log("Amunetando los limites"+Dinamic.objectsInScene.Count);
        }
    }
    public void HideObjectsStatic()
    {
        Static.objectsInScene[idS].SetActive(false);
        Vector3 posInit = new Vector3(1, 0, 0);
        Static.objectsInScene[idS].transform.position = transform.position + posInit;
        idS = (idS + 1) % (Static.objectsInScene.Count);
        if (balasUsedStatic > 0)
        {            
            balasUsedStatic--;
        }
    }
}
