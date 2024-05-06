using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ObjectPool", menuName = "ScriptableObject/ObjectPool/Object")]
public class SO_ObjectPool : ScriptableObject
{
    public GameObject Prefab;
    public Rigidbody rgbPrefab;
    public HandleMessage ActiveObject;
    public HandleMessage DesactiveObject;
 
    private void OnEnable()
    {
        rgbPrefab = Prefab.GetComponent<Rigidbody>();
        ActiveObject.ActionGeneral += OnObjectActivated;
        DesactiveObject.ActionGeneral += OnObjectActivated;
    }
    public virtual void OnObjectActivated()
    {
        Prefab.SetActive(true);
    }

    public virtual void OnObjectDeactivated()
    {
        Prefab.SetActive(false);
    }
    private void OnDisable()
    {
        //ActiveObject.ActionGeneral -= OnObjectActivated;
        //DesactiveObject.ActionGeneral -= OnObjectActivated;
    }

}
