using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGsound.Instance.gameObject.GetComponent<AudioSource>().Pause();            //Pauses the music that is classed as Dont destroy on load
    }

    // Update is called once per frames
    void Update()
    {
        
    }
}
