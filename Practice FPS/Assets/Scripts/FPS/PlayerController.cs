using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Variables")]
   [SerializeField] private float moveSpeed;
   [SerializeField] private float walkSpeed;
   [SerializeField] private float runSpeed;
   [SerializeField] private float jumpForce;

   private Vector3 moveDirection = Vector3.zero;

   private CharacterController controller;

  [Header("Gravity")]
  [SerializeField] private float gravity;
  [SerializeField] private float groundDistance = 0.5f;
  [SerializeField] private LayerMask groundMask;
  [SerializeField] private bool isPlayerGrounded = false;

  private Vector3 velocity = Vector3.zero;
   private void Start()
   {
    getReferences();
    initVariables();
       
         
   }


   private void Update() {


 


    handleIsGrounded();

    handleJump();
    handleGravity();

    
    handleRunning();
    handleMovement();
        

   }



   private void handleIsGrounded() {
           isPlayerGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
   }

   private void handleJump() {
      if(Input.GetKeyDown(KeyCode.Space) && isPlayerGrounded) {
        velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
    }

   }

    private void handleRunning() {

            if(Input.GetKeyDown(KeyCode.LeftShift)) {
        moveSpeed = runSpeed;
    }
    if(Input.GetKeyUp(KeyCode.LeftShift)) {
        moveSpeed = walkSpeed;

    }
    }
   private void handleMovement() {
            float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = moveDirection.normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

   }

    private void handleGravity() {
        if(isPlayerGrounded && velocity.y < 0) 
    {
        velocity.y = -2f;
    }

    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);

    }
   private void getReferences() {
     controller = GetComponent<CharacterController>();

   }
   private void initVariables() {
    
    moveSpeed = walkSpeed;
   }



}
