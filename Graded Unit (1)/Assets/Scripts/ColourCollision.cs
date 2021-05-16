using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourCollision : MonoBehaviour
{
        
    public BetterJump betterjump;
    

    // Start is called before the first frame update
    void Start()
    {
        betterjump = GetComponent<BetterJump>();        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)      //Checks every time a hitbox collision is triggered
    {

        if (collider.tag != gameObject.tag && collider.tag != "Solid" && collider.tag != "Coin")       //A check to see if the object we have collided with has a tag that doesnt match the colour of the player
        {           
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collider.gameObject.GetComponent<Collider2D>(), true);         //Stops the 2 hit boxes from interacting with each other allowing the player to walk through it
        }
        else
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collider.gameObject.GetComponent<Collider2D>(), false);

        }
        
    }

    private void OnTriggerStay2D(Collider2D collider)       //Checks to see if a hitbox collision is still in happening
    {
                   
            if (collider.tag != gameObject.tag && collider.tag != "Solid")
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collider.gameObject.GetComponent<Collider2D>(), true);
            }
        
    }

    


}
