using UnityEngine;
using System.Collections;

//This script makes a game object rotate at a random speed.
public class Rotate : MonoBehaviour
{
    //Set a maximum spin speed for the game object, ensuring it is accessible in the Unity editor.
    [SerializeField]
    private float maximumSpinSpeed = 200;

    /*
    Use this for initialization, 
    rotation speed is randomly set between the negative and 
    positive maximum spin speed to allow for both clockwise and counterclockwise rotation.
    */
    void Start()
    {
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-maximumSpinSpeed, maximumSpinSpeed);
    }
}
