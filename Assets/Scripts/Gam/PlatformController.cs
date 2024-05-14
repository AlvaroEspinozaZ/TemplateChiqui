using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float y = 5f;
    private Camera mainCamera;
    public HandleMessage puntos;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPoint.y  < 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 2f);         


        }
        if (screenPoint.y > 1)
        {
            Destroy(gameObject, 2f);
        }
    }
    private void OnDisable()
    {
        puntos.CallEventInt(1);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("entro");
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        gameObject.GetComponent<Collider>().isTrigger = false;
    //    }
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        gameObject.GetComponent<Collider>().isTrigger = false;
    //    }
    //}
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        gameObject.GetComponent<Collider>().isTrigger = false;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        gameObject.GetComponent<Collider>().isTrigger = true;
    //    }
    //}
}
