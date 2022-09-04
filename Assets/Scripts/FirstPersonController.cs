using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 1f;
    public float runSpeed = 3f;
    public KeyCode jumpButton = KeyCode.Space;
    public KeyCode runButton = KeyCode.LeftShift;
    public float jumpPower = 300f;
    public Rigidbody rb;
    public bool groundedPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpButton) && groundedPlayer)
        {
            rb.AddForce(transform.up * jumpPower);
        }
    }

    private void Move()
    {
        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        move *= Time.fixedDeltaTime;
        move.y = 0;

        if (Input.GetKey(runButton))
            move *= runSpeed;
        else
            move *= speed;

        transform.localPosition += move;
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                groundedPlayer = true;
                break;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                groundedPlayer = false;
                break;
        }
    }

}









/*


public class Example : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 playerVelocity; 
    private bool groundedPlayer; 
    private float playerSpeed = 2.0f; 
    private float jumpHeight = 1.0f; 
    private float gravityValue = -9.81f;

    private void Start() { controller = gameObject.AddComponent<CharacterController>(); }

    void Update()
    {
        groundedPlayer = controller.isGrounded; 
        if (groundedPlayer && playerVelocity.y < 0) { 
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) { gameObject.transform.forward = move; }

        if (Input.GetButtonDown("Jump") && groundedPlayer)  
        {  
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);  
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
*/