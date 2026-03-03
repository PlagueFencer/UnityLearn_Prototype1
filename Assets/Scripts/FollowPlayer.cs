using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public int playerNumber = 1; // 1 for Player 1, 2 for Player 2
    
    private Vector3 thirdPersonOffset = new Vector3(0, 5, -7);
    private Vector3 firstPersonOffset = new Vector3(0, 1.5f, 0.8f);
    private Vector3 currentOffset;
    private bool isFirstPerson = false;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        currentOffset = thirdPersonOffset;
        cam = GetComponent<Camera>();
        
        // Set up split screen viewports
        if (cam != null)
        {
            if (playerNumber == 1)
            {
                // Player 1 gets top half of screen
                cam.rect = new Rect(0, 0.5f, 1, 0.5f);
            }
            else if (playerNumber == 2)
            {
                // Player 2 gets bottom half of screen
                cam.rect = new Rect(0, 0, 1, 0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle camera view with V key for Player 1, B key for Player 2
        KeyCode toggleKey = playerNumber == 1 ? KeyCode.V : KeyCode.B;
        
        if (Input.GetKeyDown(toggleKey))
        {
            isFirstPerson = !isFirstPerson;
            currentOffset = isFirstPerson ? firstPersonOffset : thirdPersonOffset;
        }

        // Offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + player.transform.TransformDirection(currentOffset);

        // In first person, match the player's rotation exactly
        if (isFirstPerson)
        {
            transform.rotation = player.transform.rotation;
        }
        else
        {
            // In third person, look at the player
            transform.LookAt(player.transform.position + Vector3.up * 1.5f);
        }
    }
}
