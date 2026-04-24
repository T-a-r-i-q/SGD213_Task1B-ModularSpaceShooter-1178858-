using UnityEngine;

/// <summary>
/// PickupBase is an abstract class that serves as a base for all pickup types in the game. 
/// It handles the common functionality of detecting player collisions and delegating the specific pickup logic 
/// to derived classes through the HandlePlayerPickup method.
/// </summary>
public abstract class PickupBase : MonoBehaviour
{
    // OnTriggerEnter2D and OnCollisionEnter2D both call TryPickup to handle player interactions with the pickup.
    private void OnTriggerEnter2D(Collider2D col)
    {
        TryPickup(col.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        TryPickup(col.gameObject);
    }

    /// <summary>
    /// TryPickup checks if the colliding object is tagged as "Player". If it is, it calls the HandlePlayerPickup 
    /// method. If the pickup is successful, it destroys the pickup game object. This method centralizes the logic 
    /// for handling player pickups.
    /// </summary>
    /// <param name="other"></param>
    private void TryPickup(GameObject other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        bool pickupSuccessful = HandlePlayerPickup(other);

        if (pickupSuccessful)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// HandlePlayerPickup is an abstract method that must be implemented by derived classes to define the specific 
    /// logic for each pickup type.
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    protected abstract bool HandlePlayerPickup(GameObject player);
}