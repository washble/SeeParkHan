using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                    Debug.Log("No Singleton obj");
            }
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        // DontDestroyOnLoad(gameObject);   // if you wanna maintain gamemanager to next scene, delete comment out
    }

    // write your code under the here!!
    
}
