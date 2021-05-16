using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLights : MonoBehaviour
{
    public int FurthestPosistion;
    public float DiscoTime;
    Vector3 p;
    private float TimeTimeTime;
    // Start is called before the first frame update
    void Start()
    {
        p = transform.position;
        TimeTimeTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
       // if (DiscoTime > 0)
       // {
            DiscoTime -= Time.deltaTime;
       // }

        if(DiscoTime < 0)
        {
            p.x++;
            TimeTimeTime -= Time.deltaTime;
            if(TimeTimeTime < 0)
            {
                DiscoTime = 0.5f;
                TimeTimeTime = 0.5f;
            }
            
            
        }else if(DiscoTime > 0)
        {
            p.x--;
           
        }  
            transform.position = p;  // you can set the position as a whole, just not individual fields
        
    }
}
