using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PickupHealth is a concrete implementation of PickupBase that provides health restoration functionality to the 
/// player. 
/// </summary>
public class PickupHealth : PickupBase
{
    // healingAmount is the amount of health that will be restored to the player upon picking up this item.
    [SerializeField]
    public int healingAmount;

    /// <summary>
    /// HandlePlayerPickup checks if the player has an IHealth component, and if so, it calls the Heal method on 
    /// that component with the specified healingAmount. If the player does not have an IHealth component, it logs 
    /// an error and returns false, indicating that the pickup was not successful.
    /// </summary>
    /// <param name="player"></param>
    protected override bool HandlePlayerPickup(GameObject player)
    {
        IHealth playerHealth = player.GetComponent<IHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("Player doesn't have an IHealth component.");
            return false;
        }

        playerHealth.Heal(healingAmount);
        return true;
    }

}
