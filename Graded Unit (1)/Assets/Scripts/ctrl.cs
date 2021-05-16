using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrl : MonoBehaviour
{

    // initisialising Variables    
	bool isJumping;
    public Reset reset;    
	Rigidbody2D rb;
    Animator playerAnimation;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isJumppad;
    BetterJump Grounded;
    ColourSwitch Colour;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> (); // setting up rigidbody
        playerAnimation = GetComponent<Animator>(); // setting up animator    
        Grounded = GetComponent<BetterJump>();
        Colour = GetComponent<ColourSwitch>();
        
    }


	void FixedUpdate() // fixed update as changing physics 
    {
        
        if (rb.velocity.y < 0) // if falling (velocity lower than 0) 
        {
           rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; // adds Gravity + a fall multiplier and time to make the character fall faster than he climbed in the jump to make the sprite feel like it has weight
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // if the jump key didnt get held down gravity will instantly apply making a small jump but with still the weighty feeling
        {
           rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1 ) * Time.deltaTime;
        }
        playerAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); // for when animations are added.
        playerAnimation.SetBool("Grounded", Grounded.isJumping);
        playerAnimation.SetBool("Sliding", Grounded.isSliding);
        playerAnimation.SetInteger("Colour",  Colour.colour);
        if (transform.position.y <= -10)
        {
            reset.reset();
        }
        
        
    }
	
	
	
	void OnCollisionEnter2D(Collision2D other){ // collision detection 
		if (other.gameObject.CompareTag("Solid")){ // ground is tagged with solid, this detects for ground then
			isJumping = false; // if touching the ground then it registers your character as not jumping
			rb.velocity = Vector2.zero;
		}
        else if (other.gameObject.CompareTag("Kill")) { // when touching an object tagged with kill 
            reset.reset(); // reset the sprite to specified reset location
            Debug.Log("I should die right now");
        }
        else if (other.gameObject.CompareTag("JumpPad")) // When touching an object tagged with jumppad
        {
            rb.velocity += Vector2.up * 10f; // increase the players upward velocity by 10 units. 
        }
            }
        }
       
	