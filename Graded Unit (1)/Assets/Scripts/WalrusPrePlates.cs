using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalrusPrePlates : MonoBehaviour
{
    public walrusBackground PartyTime;
    public bool disco;
    private Sprite defaultSprite;
    public bool active = false;
    public Walrus walrus;
    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = GetComponent<SpriteRenderer>().sprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        disco = PartyTime.DiscoTime;

        

        
        if (disco == true && active != true)                                                //Same as pressureplate script
        {
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
            this.GetComponent<BoxCollider2D>().enabled = true;
            
        }
        else if (disco == false)
        {
            GetComponent<SpriteRenderer>().sprite = null;
            this.GetComponent<BoxCollider2D>().enabled = false;
            active = false;
            if (walrus.Score > 0)                                                       //Resets the score of the Walrus if not pressed fast enough
            {
                walrus.Score = 3;
            } 
        }

        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(this.tag)&& other.gameObject.name.Equals("Klyde"))         //Checks for collision with player and player tag
        {
            active = true;                                                                         //Turn off hitbox removes sprite and reduces the Walrus score by 1
            walrus.Score--;
            GetComponent<SpriteRenderer>().sprite = null;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }




}
