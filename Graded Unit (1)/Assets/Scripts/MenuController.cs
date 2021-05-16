using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public int index;
    public bool KeyDown;
    public int maxIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            //if (!KeyDown)

            if (index < maxIndex)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        else if (Input.GetAxis("Vertical") > 0)
        {
            if (index > 0)
            {
                index--;
            }
            else
            {
                index = maxIndex;
            }
        }
            //KeyDown = true;
        }
    }

       
    


    
