using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwitch : MonoBehaviour
{

    //Create all required variables for code    
    public Sprite Blue, Red, Yellow;
    public int colour;
    public string c;
    public AudioClip CChange;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        colour = 0;
        c = "Black";
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //Checks for keys 1-6 (above letters not numpad) and the player tag changes based on key press

        if (Input.GetKeyDown("j"))
        {
            gameObject.tag = "Blue";        //Pressing j makes Colour = Blue
            this.GetComponent<SpriteRenderer>().sprite = Blue;
            colour = 1;
            c = "Blue";
            audio.PlayOneShot(CChange,0.4f);
        }

        if (Input.GetKeyDown("k"))
        {
            gameObject.tag = "Red";         //Pressing k makes Colour = Red
            this.GetComponent<SpriteRenderer>().sprite = Red;
            colour = 2;
            c = "Red";
            audio.PlayOneShot(CChange,0.4f);
        }

        if (Input.GetKeyDown("l"))
        {
            gameObject.tag = "Yellow";      //Pressing l makes Colour = Yellow
            this.GetComponent<SpriteRenderer>().sprite = Yellow;
            colour = 3;
            c = "Ylw";
            audio.PlayOneShot(CChange,0.4f);
        }
    }

}

