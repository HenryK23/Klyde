using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGsound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                                                                                    //Used to create an Audio source that isnt destroyed between levels
    }

    private static BGsound instance = null;

    public static BGsound Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}﻿

