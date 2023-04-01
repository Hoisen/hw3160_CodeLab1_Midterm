using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //this static var will hold the Singleton

    int currentLevel = 0;


    


    void Awake()
    {
        if (instance == null) //instance not set yet
        {
            DontDestroyOnLoad(gameObject);  //PLZ DONT Destroy this object when load a new scene
            instance = this;  //set instance to this obj
        }
        else  //if is already set
        {
            Destroy(gameObject);//only one will survive
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


}
