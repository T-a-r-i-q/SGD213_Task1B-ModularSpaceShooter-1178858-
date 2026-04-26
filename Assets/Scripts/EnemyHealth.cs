using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the health of an enemy. It implements the IHealth interface, which means it has to have 
/// the Heal, TakeDamage, and Die functions. However, since enemies don't heal, the Heal function doesn't do 
/// anything. The TakeDamage function reduces the current health by the damage amount and checks if the enemy 
/// should die. The Die function destroys the enemy game object.
/// </summary>
public class EnemyHealth : MonoBehaviour, IHealth {
    
    // the current health of the enemy
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    // the maximum health of the enemy
    [SerializeField]
    protected int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    //Initializes the current health to the maximum health at the start of the game
    void Start() {

        currentHealth = maxHealth;
    }

    // Since enemies don't heal, this function doesn't do anything currently. However must be implemented to 
    // satisfy the IHealth interface.
    public void Heal(int healingAmount) {

        // Do nothing 
    }

    /// <summary>
    /// Reduces the current health by the damage amount and checks if the enemy should die. If the current health
    /// is less than or equal to 0, it sets the current health to 0 and calls the Die function. Otherwise, it just
    /// reduces the current health by the damage amount.
    /// </summary>
    /// <param name="damageAmount"> The amount of damage to take.</param>
    public void TakeDamage(int damageAmount) {

        currentHealth -= damageAmount;

        if (currentHealth <= 0) {

            currentHealth = 0;
            Die();
        }
    }

    // Destroys the enemy game object. This function could be expanded to include death animations or other effects.
    public void Die() {

        // would be good to do some death animation here maybe
        // remove this object from the game
        Destroy(gameObject);
    }
}
