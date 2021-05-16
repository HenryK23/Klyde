using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball_left : MonoBehaviour
{
    public float Speed;

    public GameObject Cannon;
    Rigidbody2D rb;
    private float Despawn;
    public GameObject LftCannonBall;



    // Start is called before the first frame update
    void Start()
    {
        Despawn = 3f;
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.right * -500);
        rb.AddRelativeForce(Vector2.up * 10);


    }

    // Update is called once per frame
    void Update()
    {

        Despawn -= Time.deltaTime;
        if (Despawn < 0)
        {
            Destroy(LftCannonBall);
            Despawn = 3f;
            //rb.velocity = new Vector2(7 * Speed, rb.velocity.y);
        }

        
    }
}

