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
    [SerializeField]
    private GameObject Camera;
    [SerializeField]
    private GameObject dashDamageArea;
    [SerializeField]
    private AudioClip audioDashDamageArea;

    public Transform cam;
    

    private float xInput;
    private float yInput;

    public float volume;

    private Vector3 playerTransformVector;
    private Vector3 jump;
    public bool isGrounded;
    public bool dashActive;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f) * Time.deltaTime;
        playerTransformVector = GetComponent<Transform>().position;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded) //dash down
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(-jump * jumpForce, ForceMode.Impulse);
            dashActive = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;       
        }
        if (other.CompareTag("Ground") && dashActive==true)
        {
            dashActive = false;
            AudioSource.PlayClipAtPoint(audioDashDamageArea, cam.position,volume);
            Camera.GetComponent<CameraController>().shakeDuration = 0.2f;
            Instantiate(dashDamageArea, GetComponent<Transform>().position, Quaternion.identity );
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
