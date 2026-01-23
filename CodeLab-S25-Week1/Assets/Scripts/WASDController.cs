using UnityEngine;
using UnityEngine.InputSystem;
    
public class WASDController : MonoBehaviour
{ 
    Rigidbody rb; //rigidbody for the GameObject that this script is attached to

    public float moveForce = 10f; //the force we add to a GameObject to make it move

    public Key keyUp = Key.W; //the key we press to make GameObject go up for use with new input system

    public Key keyDown = Key.S; //the key we press to make GameObject go down for use in new input system

    Keyboard keyboard = Keyboard.current;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (keyboard[keyUp].isPressed)
        {
            rb.AddForce(Vector3.up * moveForce, ForceMode.Acceleration); //give GameObject an upward force
            Debug.Log ("going up!");
        }

        if (keyboard[keyDown].isPressed)
        {
            rb.AddForce(Vector3.down* moveForce, ForceMode.Acceleration); //give GameObject a downward force
            Debug.Log ("going down!");
        }

        
        
        // if(Input.GetKey(KeyCode.S))
        // {
        //     rb.AddForce(Vector3.down * moveForce, ForceMode.Acceleration); // give the GameObject a downward force
        // }
    }
}