using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    public float jumpForce = 2.0f;
    [SerializeField]
    private Rigidbody rb;

    public Transform cam;

    private float xInput;
    private float yInput;

    private Vector3 jump;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f) * Time.deltaTime;
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //Jumping
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("grounded");
        }
        
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
