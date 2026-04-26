using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EngineBase is a base class for any engine that can be used to move an enemy. It contains a method called 
/// Accelerate, which takes a direction as a parameter and applies a force in that direction to the enemy's 
/// Rigidbody2D component, based on the acceleration variable and the delta time.
/// </summary>
public class EngineBase : MonoBehaviour {
    
    // acceleration indicates how fast the enemy accelerates
    [SerializeField]
    protected float acceleration = 5000f;

    // local references
    protected Rigidbody2D ourRigidbody;

    protected virtual void Start() {

        // populate ourRigidbody
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Accelerate takes a direction as a parameter, and applies a force in this provided direction
    /// to ourRigidbody, based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="direction"> A direction vector, expected to be a unit vector (magnitude of 1). </param>
    public void Accelerate(Vector2 direction) {

        if (direction.magnitude != 0) {

            //calculate our force to add
            Vector2 forceToAdd = direction.normalized * acceleration * Time.deltaTime;
            // apply forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAdd);
        }
    }
}
