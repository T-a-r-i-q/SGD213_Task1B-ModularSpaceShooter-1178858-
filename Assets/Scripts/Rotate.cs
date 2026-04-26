using UnityEngine;
using System.Collections;

/// <summary>
/// This script is responsible for applying a random rotational speed to the game object it is attached to,
/// creating a spinning effect. The speed is determined by a maximum spin speed that can be set.
/// </summary>
public class Rotate : MonoBehaviour {

    //Set a maximum spin speed for the game object, ensuring it is accessible in the Unity editor.
    [SerializeField]
    private float maximumSpinSpeed = 200;

    /*
    Use this for initialization, 
    rotation speed is randomly set between the negative and 
    positive maximum spin speed to allow for both clockwise and counterclockwise rotation.
    */
    void Start() {
        
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-maximumSpinSpeed, maximumSpinSpeed);
    }
}
