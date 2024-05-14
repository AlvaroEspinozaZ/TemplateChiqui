using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float x = 4;
    public float continueForce = 0.2f;
    public HandleMessage muerte;

    private Rigidbody rgb;
    [Header("Raycast")]
    public Transform initRaycast;
    public float distanceToGround = 10f;
    public LayerMask groundLayer;
    void Start()
    {
      
        rgb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si se toca la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchInit = Camera.main.ScreenToWorldPoint(touch.position);
                Vector3 direction = new Vector3(touchInit.x - transform.position.x,0,0).normalized;

                RaycastHit hit;

                if (Physics.Raycast(initRaycast.position, -Vector3.up, out hit, distanceToGround + 0.1f, groundLayer))
                {
                    hit.collider.isTrigger = false;
                    rgb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    rgb.AddForce(direction * x, ForceMode.Impulse);
                }
                else
                {
                    if(hit.collider!=null)
                        hit.collider.isTrigger = true;
                }
                rgb.AddForce(direction * continueForce, ForceMode.Impulse);
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Muerte")
        {
           
            muerte.CallEventGeneral();
         
        }
    }
}
