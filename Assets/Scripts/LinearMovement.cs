using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script applies a linear movement to the GameObject it's attached to.
The movement is in a specified direction with an initial velocity and constant acceleration.
You can set the direction, initial velocity, and acceleration in the inspector.
The script uses Rigidbody2D to apply forces, so make sure the GameObject has a Rigidbody2D component.
*/
public class LinearMovement : MonoBehaviour
{
    // Enum to specify movement direction
    private enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    // Inspector fields to set movement parameters
    [SerializeField] private MoveDirection direction = MoveDirection.Up;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float initialVelocity = 5f;

    // Private variables to store Rigidbody2D and movement vector
    private Rigidbody2D ourRigidbody;
    private Vector2 moveVector;

    //Initialize the Rigidbody2D and set the initial velocity in the Start method
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

        moveVector = GetDirectionVector(direction);

        ourRigidbody.velocity = moveVector * initialVelocity;
    }

    // Apply acceleration in the FixedUpdate method to ensure consistent physics updates
    void FixedUpdate()
    {
        Vector2 forceToAdd = moveVector * acceleration * Time.fixedDeltaTime;
        ourRigidbody.AddForce(forceToAdd);
    }

    // Convert enum to actual direction vector
    private Vector2 GetDirectionVector(MoveDirection dir)
    {
        switch (dir)
        {
            case MoveDirection.Up:
                return Vector2.up;
            case MoveDirection.Down:
                return Vector2.down;
            case MoveDirection.Left:
                return Vector2.left;
            case MoveDirection.Right:
                return Vector2.right;
            default:
                return Vector2.up;
        }
    }
}