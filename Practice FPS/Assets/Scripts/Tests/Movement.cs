using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] Transform groundCheck;
     Rigidbody rb;
     [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);

        if(Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            
        }
    }

    // bool isGrounded() {
    //     Physics.CheckSphere(groundCheck.position, .1f, ground)

    // }
}
