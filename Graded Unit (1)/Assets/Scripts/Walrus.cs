using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walrus : MonoBehaviour
{
    public GameObject Player;
    [serializedfields]public bool grounded;
    Rigidbody2D rb;
    public float move;
    public float Height;
    public cameraShake Shake;
    public bool vunerable;
    public int walrusHealth;
    public bool end;
    float endtimer = 2f;
   // Animator playerAnimation;

    public int Score = 3;
    // Start is called before the first frame update
    void Start()
    {
        end = false;
        vunerable = false;
        rb = GetComponent<Rigidbody2D>();
        walrusHealth = 2;
        
       // playerAnimation = GetComponent<Animator>(); // setting up animator
    }

    // Update is called once per frame
    void Update()
    {

        if(walrusHealth <= 0)                                                   //This is for when the boss is dead 
        {                                                                       //Boss jumps slightly and falls down through ground
            if (endtimer >= 1.5f)
            {
                rb.velocity = new Vector2(0, Height);
            }
            else {
                rb.velocity = new Vector2(0, -Height);
            }
            this.GetComponent<PolygonCollider2D>().enabled = false;            
            endtimer -= Time.deltaTime;
            if (endtimer <= 0)
            {
                end = true;                                                 
            }
        }

        if (end)
        {
            SceneManager.LoadScene("StartMenu");                              //If the boss is dead loads the Main menu
        }

        if (Score >= 1)
        {
            vunerable = false;                                                //Used for the player to be able to hit the boss


            if (Player.transform.position.x > transform.position.x)           //Tracks player location to jump towards them
            {
                transform.localScale = new Vector2(-3f, 3f);
            }
            else if (Player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(3f, 3f);
            }


            if (grounded)
            {
               
                rb.velocity = new Vector2(-1 * move * transform.localScale.x, Height);


                

                grounded = false;
                Shake.shakeDuration = 0.5f;
               // playerAnimation.SetBool("Grounded", grounded);
            }
            
        }
        if (Score == 0)
        {
            vunerable = true;
        }
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //Checks for "Solid" tag to check for ability to jump
        if (other.gameObject.CompareTag("Solid"))
        {
            grounded = true;
           
        }

        if (vunerable == true && other.gameObject.name.Equals("Klyde"))
        {
            
            walrusHealth--;
            Score = 3;  
        }
    }
    
}
