using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public int score = 0;
    private float Shealth;    
    public Reset reset;
    Walrus vulnerable;
    private float healthTimer;
    public AudioClip hurt, coin;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        Shealth = health;
        healthTimer = 1f;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthTimer -= Time.deltaTime;
        if (health < 1)
        {
            reset.reset();
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        
        if (healthTimer <= 0)
        {
            

            if (collider.gameObject.tag == gameObject.tag)
            {
                if (collider.gameObject.name.Contains("CannonBall") || collider.gameObject.name.Contains("Spike"))
                {
                    Destroy(collider.gameObject);
                    health--;
                    healthTimer = 2f;
                    audio.PlayOneShot(hurt);
                }
            }
            else if (collider.gameObject.name.Equals("Walrus"))
            {
                vulnerable = collider.gameObject.GetComponent<Walrus>();
                if (vulnerable.vunerable == false)
                {
                    health--;
                    healthTimer = 2f;
                    audio.PlayOneShot(hurt);
                }                
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Coin"))
        {
            score = score + 10;
            audio.PlayOneShot(coin, 0.5f);
            Destroy(collision.gameObject);
        }
    }




}
