using UnityEngine;

/// <summary>
/// Inherits from EngineBase, and handles all of the movement specifc state and behaviour for the enemy.
/// </summary>
public class EnemyMovement : EngineBase {

    /// <summary>
    /// MoveEnemy takes a direction as a parameter, and applies a force in this provided direction
    /// to ourRigidbody, based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="direction"></param>
    public void MoveEnemy(Vector2 direction) {
        
        // a horizontalInput of 0 has no effect, as we want our ship to drift
        if (direction.magnitude != 0)
        {
            Accelerate(direction);
        }
    }
}
