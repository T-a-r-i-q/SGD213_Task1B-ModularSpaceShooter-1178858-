using UnityEngine;
using System.Collections;

/// <summary>
/// MoveConstantly gives an object the ability to continuously move based on the
/// specified direction, acceleration and initialVelocity variables.
/// </summary>
public class MoveConstantly : MonoBehaviour {

    // variables to control our movement
    [SerializeField]
    private float acceleration = 100f;

    [SerializeField]
    private float initialVelocity = 10f;

    // our direction to move in, defaulting to up (0, 1), use (0, -1) for down, (-1, 0) for left and (1, 0) for right
    [SerializeField]
    private Vector2 direction = new Vector2(0, 1);

    /// <summary>
    /// Direction provides access to the direction variable used to direct the movement of our object.
    /// It is expected that when setting the direction, the provided Vector2 is a unit vector. If not,
    /// it will be automatically normalised.
    /// </summary>
    public Vector2 Direction {
        get {

            return direction;
        }
        set {

            if (value.magnitude == 1) {
                direction = value;
            } else {

                direction = value.normalized;
            }
        }
    }

    // local references
    private Rigidbody2D ourRigidbody;

    // Use this for initialization
    void Start() {

        // get our Rigidbody2D component and set our initial velocity
        ourRigidbody = GetComponent<Rigidbody2D>();

        // set our initial velocity based on our direction and initialVelocity variables
        ourRigidbody.velocity = direction * initialVelocity;
    }

    // Update is called once per frame, we use it to add a force to our Rigidbody2D to keep it moving
    void Update() {

        // calculate our force to add, based on our provided direction, acceleration and delta time
        Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
        // add our forceToAdd to ourRigidbody
        ourRigidbody.AddForce(forceToAdd);
    }
}
