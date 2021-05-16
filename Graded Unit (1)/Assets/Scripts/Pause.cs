using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))        //When esscape is pressed
        {
            if (Paused == true)                     //If paused game will resume and vice versa
            {
                Resume();
            }
            else
            {
                Pausee();
            }
        }


        
    }

    public void Resume()                //Resume time "starts" objects          
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false; 
    }
    void Pausee()                       //Stops time "freezes" objects   
    {
        Debug.Log("Pause");
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Exit()              //Exits loads the startmenu
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
}
