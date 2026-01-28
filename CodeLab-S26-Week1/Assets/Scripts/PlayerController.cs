using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //this variable stores the rigidbody
    private Rigidbody rb;

//this variable stores the speed of the player Game Object
    public float moveSpeed = 5f;

//this variable stores the jump speed of the player Game Object    
    public float jumpSpeed = 5f;

//this variable stores the rotate speed for the look action
    //public float lookSpeed;

//variable to hold the input action asset, gives access to all actions in asset
    public InputActionAsset inputActions;

//for each action used create a variable to store them
    private InputAction moveAction;
    private InputAction jumpAction;

    private bool isGrounded;

//these variables store the x and y-axis values
    private Vector2 moveAmount; 
//activates the action map if the player Game Object is active in the scene
    private void OnEnable()
        {
            inputActions.FindActionMap("Player").Enable();
        }
//if player Game Object is destroyed then this disables the action map    
    private void OnDisable()
        {
            inputActions.FindActionMap("Player").Disable();
        } 
    // public void Start()
    // {
    //     //InputActions = Resources.Load<InputActionAsset>("InputActions");
    //     
    // }
    //
    private void Awake()
    {
 //assigns jump and move actions to respective actions in the input system       
        moveAction = inputActions.FindActionMap("Player").FindAction("Move");
        jumpAction = inputActions.FindActionMap("Player").FindAction("Jump");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveAmount = moveAction.ReadValue<Vector2>();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpSpeed, rb.linearVelocity.z);

    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.linearVelocity = new Vector3(moveAmount.x * moveSpeed, rb.linearVelocity.y, moveAmount.y * moveSpeed);
        //rb.MovePosition(rb.position + transform.position * moveAmount.y * moveSpeed * Time.deltaTime);
        // if (moveAction.IsPressed()) 
        // { 
        //     Vector2 input = moveAction.ReadValue<Vector2>();
        //     Vector3 movement = new Vector3(input.x, 0, input.y) * moveSpeed;
        //     rb.AddForce(movement, ForceMode.Force);
        //;
    }
}
