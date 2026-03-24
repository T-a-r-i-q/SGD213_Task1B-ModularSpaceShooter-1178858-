using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is responsible for taking player input and calling the appropriate functions 
in our other scripts reducing update clutter and making our code more modular
*/
public class PlayerInput : MonoBehaviour
{
    // create references to our other scripts so we can call their functions
    private PlayerMovementScript playerMovementScript;
    private ShootingScript shootingScript;
    
    // Start is called before the first frame update, we will use this to initialize our script references
    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
        shootingScript = GetComponent<ShootingScript>();
    }

    /*
    Update is called once per frame, we will use this to check for player input and call 
    the appropriate functions in our other scripts.
    */
    void Update()
    {
        // Get the horizontal input axis (A/D keys or Left/Right arrow keys)
        float HorizontalInput = Input.GetAxis("Horizontal");

        // If there is horizontal input, call the MoveHorizontal function in our PlayerMovementScript
        if (HorizontalInput != 0.0f) 
        {
            playerMovementScript.MoveHorizontal(HorizontalInput);
        }   

        /*
        If the player presses the fire button (default is left ctrl or mouse left click), 
        call the shoot function in our ShootingScript, but only if we have a reference to it! 
        (if shootingScript is not null)
        */
        if (Input.GetButton("Fire1"))
        {
            if (shootingScript != null)
            {
                shootingScript.Shoot();
            }
            else
            {
                Debug.Log("ShootingScript not found on player!");
            }
        }
    }
}
