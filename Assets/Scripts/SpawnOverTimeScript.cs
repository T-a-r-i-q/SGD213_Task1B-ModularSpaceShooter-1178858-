using UnityEngine;
using System.Collections;

/*
This script is attached to the spawner game object. It spawns a given object at random positions 
within the bounds of the spawner, and it does this repeatedly over time.
*/
public class SpawnOverTimeScript : MonoBehaviour
{

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
    void Start()
    {

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
    void Spawn()
    {
        float x1 = transform.position.x - ourRenderer.bounds.size.x / 2;
        float x2 = transform.position.x + ourRenderer.bounds.size.x / 2;

        // Randomly pick a point within the spawn object
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Spawn the object at the 'spawnPoint' position
        Instantiate(spawnObject, spawnPoint, Quaternion.identity);
    }
}
