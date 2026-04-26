using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DestroyedOnCollision gives the attached object a collision behaviour, that will destroy the
/// attached object depending on a list of tags, and whether they should be considered, or ignored.
/// Inheriting from DetectCollisionBase, the collision behaviour is defined in ProcessCollision, which will be 
/// called by the base class when a collision is detected.
/// </summary>
public class DestroyedOnCollision : DetectCollisionBase {
    
    protected override void ProcessCollision(GameObject other) {
        base.ProcessCollision(other);
        Destroy(gameObject);
        //Destroy(other); changed from above
    }
}
