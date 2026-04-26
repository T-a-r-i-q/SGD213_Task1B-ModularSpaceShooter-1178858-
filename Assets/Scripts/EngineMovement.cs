using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inherits from EngineBase, and handles all of the movement behaviour for ships.
/// </summary>
public class EngineMovement : EngineBase {

    /// <summary>
    /// Move takes a direction as a parameter, and applies a force in this provided direction
    /// to ourRigidbody, based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="direction"> The direction in which to move. </param>
    public void Move(Vector2 direction) {

        // a horizontalInput of 0 has no effect, as we want ships to drift
        if (direction.magnitude != 0) {
            
            Accelerate(direction);
        }
    }
}
