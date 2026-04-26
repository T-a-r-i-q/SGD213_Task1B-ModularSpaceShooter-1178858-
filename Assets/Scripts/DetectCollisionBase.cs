using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class detects collisions with other objects and processes them based on a list of tags.
/// </summary>
public class DetectCollisionBase : MonoBehaviour{

    // Determines whether the list of tags is a Blacklist (objects with these tags will trigger the collision) 
    // or a Whitelist (objects without these tags will trigger the collision)
    [SerializeField]
    private TagListType tagListType = TagListType.Blacklist;

    // A list of tags which we use to determine whether to explode or not
    // Depending on the tagListType (Blacklist or Whitelist)
    [SerializeField]
    private List<string> tags;

    /// <summary>
    /// Detects when another collider enters the trigger collider attached to this object and processes the 
    /// collision based on the tag list.
    /// </summary>
    /// <param name="other"> The collider that triggered the collision.</param>
    void OnTriggerEnter2D(Collider2D other) {

        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist && tagInList) {

            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            ProcessCollision(other.gameObject);
        } else if (tagListType == TagListType.Whitelist && !tagInList) {

            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            ProcessCollision(other.gameObject);
        }
    }

    /// <summary>
    /// Detects when another collider enters the non-trigger collider attached to this object and processes the 
    /// collision based on the tag list.
    /// </summary>
    /// <param name="other"> The collider that triggered the collision.</param>
    void OnCollisionEnter2D(Collision2D other) {
        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist && tagInList) {

            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            ProcessCollision(other.gameObject);
        } else if (tagListType == TagListType.Whitelist && !tagInList) {

            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            ProcessCollision(other.gameObject);
        }
    }

    /// <summary>
    /// Processes the collision with the specified game object.
    /// </summary>
    /// <param name="other"> The game object that triggered the collision.</param>
    protected virtual void ProcessCollision(GameObject other) {

        print("Detected collision with " + other.name);
    }
}

// Defines the type of tag list to use for collision detection: Blacklist or Whitelist
public enum TagListType {
    Blacklist,
    Whitelist
}

