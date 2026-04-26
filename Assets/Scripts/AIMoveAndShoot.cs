using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple AI script that moves the enemy in a random direction downwards and shoots at the player. 
/// It requires an EngineMovement component to move and a WeaponBase component to shoot.
/// </summary>
public class AIMoveAndShoot : MonoBehaviour {

    // state
    private Vector2 movementDirection;

    // local references
    private EngineMovement enemyMovement;
    private WeaponBase weapon;

    // Use this for initialization
    void Start() {
        // populate our local references
        enemyMovement = GetComponent<EngineMovement>();
        weapon = GetComponent<WeaponBase>();

        // get a random direction between South-East and South-West
        float x = Random.Range(-0.5f, 0.5f);
        float y = -0.5f;
        movementDirection = new Vector2(x, y).normalized; // ensure it is normalised
    }

    // Update is called once per frame
    void Update () {
        // move our enemy if we have a EngineMovement component attached
        if (enemyMovement != null) {
            enemyMovement.Move(movementDirection);
        }

        // shoot if we have a IWeapon component attached
        if (weapon != null) {
            weapon.Shoot();
        }
    }
}
