using UnityEngine;
using System.Collections;

// This script is responsible for shooting bullets when the player presses the fire button
public class ShootingScript : MonoBehaviour
{

    // The bullet prefab that we will spawn when we shoot, set this in the Editor with serializeField
    [SerializeField]
    private GameObject bullet;

    // We will use this to make sure we don't shoot too many bullets at once
    private float lastFiredTime = 0f;

    // How long we have to wait between shots, set this in the Editor with serializeField
    [SerializeField]
    private float fireDelay = 1f;

    // This is how far in front of the player we will spawn the bullet, we will calculate this in Start()
    private float bulletOffset = 2f;

    //initialize our variables
    void Start()
    {
        // Do some math to perfectly spawn bullets in front of us
        bulletOffset = GetComponent<Renderer>().bounds.size.y / 2 // Half of our size
            + bullet.GetComponent<Renderer>().bounds.size.y / 2; // Plus half of the bullet size
    }

    /*
    This function is called by the PlayerInput script when we want to shoot, 
    it checks if we have shot recently and then spawns a bullet if we haven't
    */
    public void Shoot() 
    {
        // Get the current time
        float CurrentTime = Time.time;

        // Have a delay so we don't shoot too many bullets
        if (CurrentTime - lastFiredTime > fireDelay)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + bulletOffset);

            Instantiate(bullet, spawnPosition, transform.rotation);

            lastFiredTime = CurrentTime;
        }
    }

}
