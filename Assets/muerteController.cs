using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerteController : MonoBehaviour
{
    public Transform player;
    public Vector3 distancia;
    public Vector3 tmp;
    private void Start()
    {
        tmp.y = transform.position.y;
    }
    private void Update()
    {
        distancia = tmp - player.position;
        if (distancia.magnitude > 2.5)
        {
            tmp.y = tmp.y+ 0.1f;
        }
    }
}
