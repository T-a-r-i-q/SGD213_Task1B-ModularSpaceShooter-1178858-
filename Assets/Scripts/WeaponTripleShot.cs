using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
// WeaponTripleShot is a weapon that shoots 3 bullets at once in a spread pattern.
// It inherits from WeaponBase and overrides the Shoot method to implement the triple shot behavior.
// The spread angle can be adjusted in the inspector to control how wide the bullets spread out.
// </summary>
public class WeaponTripleShot : WeaponBase {
    
    // The angle in degrees that the bullets will spread out from the center bullet.
    [SerializeField]
    private float spreadAngle = 30f;


    // Override the Shoot method to implement the triple shot behavior.
    public override void Shoot() 
    {
        // get the current time
        float currentTime = Time.time;

        print("Shoot triple shot");
        // if enough time has passed since our last shot compared to our fireDelay, spawn our bullet
        if (currentTime - lastFiredTime > fireDelay) 
        {
            float[] angles = { -spreadAngle, 0f, spreadAngle };

            // create 3 bullets
            for (int i = 0; i < 3; i++) 
            {
                // create our bullet with the same rotation as the weapon
                GameObject newBullet = Instantiate(
                    bullet,
                    bulletSpawnPoint.position,
                    transform.rotation
                );

                // Get the MoveConstantly script from the new bullet to set its direction
                MoveConstantly moveScript = newBullet.GetComponent<MoveConstantly>();

                // Get base direction from the bullet prefab's MoveConstantly script
                Vector2 baseDirection = moveScript.Direction;

                // Apply spread rotation
                Vector2 finalDirection =
                    Quaternion.Euler(0, 0, angles[i]) * baseDirection;

                // Set the final direction to the MoveConstantly script
                moveScript.Direction = finalDirection;
            }

            // update our shooting state
            lastFiredTime = currentTime;
        }
    }    
}
