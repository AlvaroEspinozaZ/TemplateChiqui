using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ObjectPool", menuName = "ScriptableObject/ObjectPooling/SO_ObjectPooling")]
public class SO_ObjectPooling : ScriptableObject
{
    public SO_ObjectPool prefabSO;
    public int initialPoolSize = 10;
    public bool isDinamicOP = false;
    public List<GameObject> objectsInScene = new List<GameObject>();


    public void CreateOP()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewObjectInPool();
        }
    }
    private GameObject CreateNewObjectInPool()
    {
        GameObject obj = Instantiate(prefabSO.Prefab);
        objectsInScene.Add(obj);
        return obj;
    }
    
    public GameObject GetObjectFromPool()
    {
        if (isDinamicOP)
        {
            foreach (GameObject obj in objectsInScene)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            GameObject newObj = CreateNewObjectInPool();
            newObj.SetActive(true);            
            return newObj;
        }
        return null;
    }
}
