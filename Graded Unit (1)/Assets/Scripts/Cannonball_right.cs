using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball_right : MonoBehaviour
{
    public float Speed;

    public GameObject Cannon; 
    Rigidbody2D rb;

    
    private float Despawn;
    public GameObject CannonBall;



    // Start is called before the first frame update
    void Start()
    {
        Despawn = 3f;
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.right * 500 );                  //When created the cannonball shoots to the right and up a small amount to simulate an arc
        rb.AddRelativeForce(Vector2.up * 10);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Despawn -= Time.deltaTime;                                 //despawn is subtracted from every second till it hits 0 before the cannonball is destroyed
        if(Despawn < 0)
        {
            Destroy(CannonBall);
            Despawn = 3f;
            //rb.velocity = new Vector2(7 * Speed, rb.velocity.y);
        }
        
        //rb.velocity(new Vector3.right * 20); no idea. 
        // 
    }
}