using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerHealth is a concrete implementation of the IHealth interface that manages the player's health. It provides
/// functionality for taking damage, healing, and dying. The class uses serialized fields to allow for easy 
/// configuration of the player's current and maximum health in the Unity editor. The TakeDamage and Heal methods 
/// update the player's health and also update the UI health slider accordingly. When the player's health reaches 
/// zero or below, the Die method is called, which currently destroys the player GameObject.
/// </summary>
public class PlayerHealth : MonoBehaviour, IHealth {

    // currentHealth tracks the player's current health, while maxHealth defines the maximum health the player 
    // can have.
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    protected int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    // Start initializes the player's health to the maximum health at the beginning of the game.
    void Start() {

        currentHealth = maxHealth;
    }

    // <summary>
    /// Heal handles the functionality of receiving health
    /// </summary>
    /// <param name="healingAmount">The amount of health to gain, this value should be positive</param>
    public void Heal(int healingAmount) {

        currentHealth += healingAmount;

        if (currentHealth > maxHealth) {

            currentHealth = maxHealth;
        }
        // Update the UI health slider to reflect the new health value after healing.
        UIManager.instance.UpdatePlayerHealthSlider((float)currentHealth / (float)maxHealth);
    }

    /// <summary>
    /// TakeDamage handles the functionality for taking damage
    /// </summary>
    /// <param name="damageAmount">The amount of damage to lose, this value should be positive</param>
    public void TakeDamage(int damageAmount) {

        currentHealth -= damageAmount;

        // Update the UI health slider to reflect the new health value after taking damage.
        UIManager.instance.UpdatePlayerHealthSlider((float)currentHealth / (float)maxHealth);

        // Check if the player's health has reached zero or below, and if so, call the Die method to handle player 
        // death.
        if (currentHealth <= 0) {

            currentHealth = 0;
            Die();
        }
    }

    /// <summary>
    /// Handles all functionality related to when health reaches or goes below zero, should perform all necessary 
    /// cleanup.
    /// </summary>
    public void Die() {

        // would be good to do some death animation here maybe
        // remove this object from the game
        Destroy(gameObject);
    }
}
