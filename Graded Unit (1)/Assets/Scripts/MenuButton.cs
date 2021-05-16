using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public MenuController menuController;
    public Animator animator;
    public int thisIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(menuController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("Pressed", true);
            }else if (animator.GetBool("Pressed")){
                animator.SetBool("Pressed", false);
            }
        }
        
    }
}
