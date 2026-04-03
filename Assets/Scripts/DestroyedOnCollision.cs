using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
This enum is used to determine whether we are using a blacklist or whitelist of tags for our 
DestroyedOnCollision script
*/
public enum TagListType
{
    Blacklist,
    Whitelist
}

/*
This class is responsible for destroying a game object when it collides with another object 
with a certain tag, depending on whether the tag is in a blacklist or whitelist
*/
public class DestroyedOnCollision : MonoBehaviour
{

    //SerializeField allows us to edit these private variables in the inspector, 
    // which is useful for testing different tags and lists without having to change the code
    [SerializeField]
    private TagListType tagListType = TagListType.Blacklist;

    // A list of tags which we use to determine whether to explode or not
    // Depending on the tagListType (Blacklist or Whitelist)
    [SerializeField]
    private List<string> tags;

    /*
    This function is called when our game object collides with another object with a Collider2D component,
    it checks the tag of the other object against our list of tags and destroys this game object if necessary,
    ignoring the collision if the tag is not in the list (for blacklist) or is in the list (for whitelist)
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist 
            && tagInList)
        {
            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            Destroy(gameObject);
        }
        else if (tagListType == TagListType.Whitelist 
            && !tagInList)
        {
            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            Destroy(gameObject);
        }
        else
        {
            // Use default collision code
        }
    }
}
