using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton class that manages the UI elements in the game. It is responsible for updating the player's health 
/// slider and any other UI elements that may be added in the future.
/// </summary>
public class UIManager : MonoBehaviour {

    // Static instance of the UIManager class, which allows it to be accessed from other scripts without needing a 
    // reference to it.
    public static UIManager instance;

    // Reference to the player's health slider, which will be updated by the UpdatePlayerHealthSlider method.
    [SerializeField]
    private Slider sldPlayerHealth;

    // Verifies that there is only one instance of the UIManager class in the scene and assigns it to the static 
    // instance variable.
    void Start() {

        // Check if there is already an instance of the UIManager class in the scene. If there is, log an 
        // error message
        if (instance != null) {
            Debug.LogError("There is more than one UIManager in the scene, this will break the Singleton pattern.");
        }

        instance = this;
    }

    // Updates the player's health slider with the given percentage value. This method can be called from other 
    // scripts to update the player's health UI whenever the player's health changes.
    public void UpdatePlayerHealthSlider(float percentage) {

        sldPlayerHealth.value = percentage;
    }
}
