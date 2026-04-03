using UnityEngine;
using System.Collections;

// This script is responsible for moving the bullet forward and accelerating it over time
public class BulletMoveForward : MonoBehaviour {

    //Create some variables to control how fast the bullet moves initially and accelerates
    private float acceleration = 50f;

    private float initialVelocity = 5f;

    // A reference to our Rigidbody2D component, which we will use to move our bullet
    private Rigidbody2D ourRigidbody;

    // Use this for initialization of our bullet
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

        ourRigidbody.velocity = Vector2.up * initialVelocity;
    }

    /*
    Update is called once per frame
    Accelerate the bullet over time by adding more and more force in the up direction
    */
    void Update()
    {
        Vector2 forceToAdd = Vector2.up * acceleration * Time.deltaTime;

        ourRigidbody.AddForce(forceToAdd);
    }
}
