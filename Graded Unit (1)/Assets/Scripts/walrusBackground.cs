using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walrusBackground : MonoBehaviour
{
    [SerializeField] private float DiscoBallTimer;
    public bool DiscoTime = false;
    Animator Background;
    // Start is called before the first frame update
    void Start()
    {
        DiscoBallTimer = 15f;
        Background = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DiscoBallTimer -= Time.deltaTime;

        if (DiscoBallTimer < 0) 
        {
            DiscoTime = true;
            Background.SetBool("PartyTime", DiscoTime);
            //playerAnimation.SetBool("OnGround", isJumping);
            Invoke("EndDiscoTime", 15f);
        }
    }
    
    void EndDiscoTime()
    {
        DiscoTime = false;
        DiscoBallTimer =15f;
        Background.SetBool("PartyTime", DiscoTime);
    }
}
