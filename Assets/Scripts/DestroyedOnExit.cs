using UnityEngine;
using System.Collections;

/// <summary>
/// This script is responsible for destroying a game object when it leaves the viewport,
/// which is useful for destroying bullets and enemies that go off screen without having to set up colliders
/// </summary>
public class DestroyedOnExit : MonoBehaviour {

    // Called when the object leaves the viewport
    void OnBecameInvisible() {
        
        Destroy(gameObject);
    }
}
