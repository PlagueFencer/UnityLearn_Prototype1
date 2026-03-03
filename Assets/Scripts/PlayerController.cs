using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Variables
    public int playerNumber = 1; // 1 for Player 1 (WASD), 2 for Player 2 (Arrows)

    // Private Variables
    private float speed = 5.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input based on player number
        if (playerNumber == 1)
        {
            // Player 1 uses WASD keys
            horizontalInput = 0f;
            forwardInput = 0f;

            if (Input.GetKey(KeyCode.D)) horizontalInput = 1f;
            if (Input.GetKey(KeyCode.A)) horizontalInput = -1f;
            if (Input.GetKey(KeyCode.W)) forwardInput = 1f;
            if (Input.GetKey(KeyCode.S)) forwardInput = -1f;
        }
        else if (playerNumber == 2)
        {
            // Player 2 uses Arrow keys
            horizontalInput = 0f;
            forwardInput = 0f;

            if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1f;
            if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1f;
            if (Input.GetKey(KeyCode.UpArrow)) forwardInput = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) forwardInput = -1f;
        }

        //Moving forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); (Old piece of code)

        // We turn the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
