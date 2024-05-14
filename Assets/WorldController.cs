using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{

    public GameObject[] plat;
    public Transform spawnPoint; 
    public float platformDistance = 2f;
    public Vector3 savePosSpawm;
    private Camera mainCamera;
    public float y = 5f;
    public HandleMessage muerte;
    void Start()
    {
        savePosSpawm = spawnPoint.position;
        mainCamera = Camera.main;
        
        StartCoroutine(AparcionPlatform());
    }

    void Update()
    {

    }

    void SpawnPlatform()
    {
        float rdn = Random.Range(-2.82f,2.86f);
        Vector3 spawnPosition = new Vector3(rdn, savePosSpawm.y + 2.4f, savePosSpawm.z);
        Instantiate(plat[0], spawnPosition, Quaternion.identity);
    }
    IEnumerator AparcionPlatform()
    {
        SpawnPlatform();
        SpawnPlatform();
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPoint.y < 1)
        {
            savePosSpawm.y = savePosSpawm.y + 2.4f;
        }
        yield return new WaitForSecondsRealtime(3.5f);
        StartCoroutine(AparcionPlatform());
    }
    private void OnEnable()
    {
        muerte.ActionGeneral += CleanObjects;

    }
    private void OnDisable()
    {
        muerte.ActionGeneral -= CleanObjects;

    }
    public void CleanObjects()
    {
        GameObject[] objetosEnEscena = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject objeto in objetosEnEscena)
        {
            if (objeto.tag == "Plat")
            {
                Destroy(objeto);
            }
        }
    }
}
