using UnityEngine;
using System.Collections;

/// <summary>
/// This script is responsible for spawning a specified object at random positions within the bounds of the spawner,
/// at regular intervals defined by 'spawnDelay'. The spawner itself is invisible, and the spawned objects appear 
/// at the spawner's position with a random horizontal offset.
/// </summary>
public class SpawnOverTimeScript : MonoBehaviour {

    // Object to spawn
    [SerializeField]
    private GameObject spawnObject;

    // Delay between spawns
    [SerializeField]
    private float spawnDelay = 2f;

    /*
    A reference to the Renderer component of the spawner, 
    which we will use to determine the bounds for spawning and to hide the spawner itself.
    */
    private Renderer ourRenderer;

    // Use this for initialization
    void Start() {

        ourRenderer = GetComponent<Renderer>();

        // Stop our Spawner from being visible!
        ourRenderer.enabled = false;

        /*
        Call the given function after spawnDelay seconds, 
        and then repeatedly call it after spawnDelay seconds.
        */
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    // This function is responsible for spawning the object at random positions within the bounds of the spawner.
    void Spawn() {
        
        float x1 = transform.position.x - ourRenderer.bounds.size.x / 2;
        float x2 = transform.position.x + ourRenderer.bounds.size.x / 2;

        // Randomly pick a point within the spawn object
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Spawn the object at the 'spawnPoint' position
        Instantiate(spawnObject, spawnPoint, Quaternion.identity);
    }
}
