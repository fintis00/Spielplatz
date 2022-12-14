using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;
    public float fallMultiplier;

    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode dashKey= KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    bool dashActive;
    

    Vector3 moveDirection;

    public Transform cam;
    [SerializeField]
    private GameObject Camera;
    [SerializeField]
    private GameObject dashDamageArea;
    [SerializeField]
    private AudioClip audioDashDamageArea;
    public float volume;

   public PointManager pointManager;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        pointManager.setZero();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.mass = 1;
        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);
                
        MyInput();
        SpeedControl();
        if (grounded)
        {
            rb.drag = groundDrag; 
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            CheckDash();
            rb.drag = 0;
        }
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void CheckDash()
    {
        if (Input.GetKey(dashKey)) //dash down
        {
            Dash();
            dashActive = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (dashActive && grounded)
        {
            dashActive = false;
            AudioSource.PlayClipAtPoint(audioDashDamageArea, cam.position, volume);
            Camera.GetComponent<CameraController>().shakeDuration = 0.2f;
            Instantiate(dashDamageArea, GetComponent<Transform>().position, Quaternion.identity);
            CinemachineShake.Instance.ShakeCamera( 6f, 0.4f);
        }
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            grounded = false;
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Dash()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(-transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
