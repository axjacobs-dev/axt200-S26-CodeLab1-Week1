using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed;
    
    public float jumpSpeed;

    public InputActionAsset inputActions;

    private InputAction moveAction;
    
    private InputAction jumpAction;
    
    //need to add horizontal and vertical input and call it in the moveAction method
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        inputActions = Resources.Load<InputActionAsset>("InputActions");
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        moveAction = inputActions.FindAction("Move");
        jumpAction = inputActions.FindAction("Jump");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (jumpAction.IsPressed())
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        if (moveAction.IsPressed())
        {
            if (keyboard[keyLeft].isPressed)
            {
                //rb.AddForce(Vector3.left * moveForce, ForceMode.Acceleration); //give GameObject a leftward force
                transform.position += Vector3.left * Time.deltaTime;
                Debug.Log ("going left!");
            }

            if (keyboard[keyRight].isPressed)
            {
                //rb.AddForce(Vector3.right * moveForce, ForceMode.Acceleration); //give GameObject a rightward force
                //rb.linearVelocity = transform.right * moveSpeed;
                transform.position += Vector3.right * Time.deltaTime;
                Debug.Log ("going right!");
            }
        }
    }
}
