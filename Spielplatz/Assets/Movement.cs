using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;

    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody rb;



    public Transform cam;

    private float xInput;
    private float yInput;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;

        camF = camF.normalized;
        camR = camR.normalized;


        Vector3 impulse = (camF * yInput + camR * xInput) * Time.deltaTime * speed;
        impulse = impulse * speed;

        rb.AddForce(impulse);
    }
}
