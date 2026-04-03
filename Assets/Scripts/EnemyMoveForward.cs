using UnityEngine;
using System.Collections;

//This script is attached to the enemy prefab. It makes the enemy move downwards and accelerate as it moves.
public class EnemyMoveForward : MonoBehaviour {

    //Set initial values for the acceleration and velocity of the enemy.
    private float acceleration = 75f;

    private float initialVelocity = 2f;

    private Rigidbody2D ourRigidbody;

    // Use this for initialization of the enemy's movement.
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

        ourRigidbody.velocity = Vector2.down * initialVelocity;
    }

    /*
    Update is called once per frame. 
    This is where the enemy's movement is updated by adding a downward force to accelerate it.
    */
    void Update()
    {
        Vector2 forceToAdd = Vector2.down * acceleration * Time.deltaTime;

        ourRigidbody.AddForce(forceToAdd);
    }
}
