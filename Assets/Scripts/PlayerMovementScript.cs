using UnityEngine;
using System.Collections;

// This script is responsible for moving the player horizontally based on the input we get from the PlayerInputScript
public class PlayerMovementScript : MonoBehaviour 
{
    /*
    SerializeField exposes this value to the Editor, but not to other Scripts!
    It is "pseudo public"
    speed indicates how fast we accelerate Horizontally
    */

    [SerializeField]
    private float speed = 5000f;

    // A reference to our Rigidbody2D component, which we will use to move our player
    private Rigidbody2D ourRigidBody;

    // Use this for initialization
    void Start() 
    {
        /*
        Get ourRigidBodyComponent once at the start of the game and store a reference to it
        This means that we don't need to call GetComponent more than once! This makes our game faster. 
        (GetComponent is SLOW)
        */

        ourRigidBody = GetComponent<Rigidbody2D>(); 
    }

    //move the player horizontally based on the input we get from the PlayerInputScript
    public void MoveHorizontal(float horizontalInput) 
    {
        Vector2 forceToAdd=Vector2.right*horizontalInput*speed*Time.deltaTime;
        ourRigidBody.AddForce(forceToAdd);
    }
}
