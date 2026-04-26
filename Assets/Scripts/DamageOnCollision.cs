using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for dealing damage to any object that it collides with, as long as that object has 
/// an IHealth component. After dealing damage, the object will be destroyed. Inherits from DetectCollisionBase, 
/// which handles the collision detection logic and calls the ProcessCollision method when a collision is detected.
/// </summary>
public class DamageOnCollision : DetectCollisionBase {

    // The amount of damage to deal to the other object upon collision
    [SerializeField]
    private int damageToDeal;

    // This method is called when a collision is detected.
    protected override void ProcessCollision(GameObject other) {

        base.ProcessCollision(other);
        if (other.GetComponent<IHealth>() != null) {

            other.GetComponent<IHealth>().TakeDamage(damageToDeal);
        } else {
            
            Debug.Log(other.name + " does not have an IHealth component");
        }

        Destroy(gameObject);
    }
}
