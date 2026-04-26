using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PickupWeapon is a concrete implementation of PickupBase that provides weapon swapping functionality to the 
/// player. When the player collides with this pickup, it will attempt to swap the player's weapon to the one 
/// specified by the weaponType field. The HandlePlayerPickup method checks if the player has a PlayerInput 
/// component and calls the SwapWeapon method on it with the specified weaponType.
/// </summary>
public class PickupWeapon : PickupBase {

    // weaponType specifies which weapon the player should switch to when picking up this item.
    [SerializeField]
    private WeaponType weaponType;

    /// <summary>
    /// Override of the HandlePlayerPickup method from PickupBase to implement the specific behavior for weapon pickups.
    /// </summary>
    /// <param name="player"> The player GameObject that picked up the item </param>
    /// <returns></returns>
    protected override bool HandlePlayerPickup(GameObject player) {

        // Implementation for handling weapon pickup by swapping the player's weapon using the PlayerInput component.
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        // Check if the player has a PlayerInput component before attempting to swap weapons. If not, log an error and
        // return false.
        if (playerInput == null) {

            Debug.LogError("Player doesn't have a PlayerInput component.");
            return false;
        }
        
        playerInput.SwapWeapon(weaponType);
        return true;
    }
}

// WeaponType is an enumeration that defines the different types of weapons available in the game. 
// This allows for easy expansion of weapon types in the future by simply adding new values to the enum.
public enum WeaponType { machineGun, tripleShot }


