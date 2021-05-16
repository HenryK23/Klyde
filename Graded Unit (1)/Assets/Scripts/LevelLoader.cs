using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    // initialising variables
    [serializedfields]  private bool inZone; 
	
	public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        inZone = false; // Start the level not triggering anything so set it to false
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone == true){ // if you do trigger the collision start scenemanager which will 
		SceneManager.LoadScene(levelToLoad); // loading a scene with Async will load it smoother as the background is loaded before hand instead of on trigger
		}
    }
	
	void OnTriggerEnter2D(Collider2D other){ // collision detection for the object with this script on
		if (other.name == "Klyde"){ // if touching the players character
			inZone = true; // activate the scenemanager load level
		}

	}
}
