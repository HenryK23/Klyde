using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreplateListener : MonoBehaviour
{
    public Pressureplate Plate;
    bool active = false;
    private Sprite defaultSprite;

    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        active = Plate.active;                                              //Goes on an object to allow it to get information from the pressure plate
        if (active == true)                                                 
        {
            this.GetComponent<SpriteRenderer>().sprite = null;              //Checks if the Pressure plate is active if active removes the sprite making it invisible
            this.GetComponent<BoxCollider2D>().enabled = false;             //And turning off the hitbox
        }
        else if (active == false)
        {
            GetComponent<SpriteRenderer>().sprite = defaultSprite;          //Checks if the Pressure plate is inactive if inactive replaces the sprite making it visible
            this.GetComponent<BoxCollider2D>().enabled = true;              //And turning on the hitbox
        }
    }

    

}
