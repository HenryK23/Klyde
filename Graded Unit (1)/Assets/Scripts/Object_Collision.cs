using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Collision : MonoBehaviour
{

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)                           //Placed on objects that is the player
    {                                                                           //Checks to see if the object being collided with is either solid or the Walrus boss
        if (collider.tag != "Solid" || collider.name.Equals("Walrus"))          //and then turns of the collision between the 2 objects
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collider.gameObject.GetComponent<Collider2D>(), true);
        }        
    }
}
