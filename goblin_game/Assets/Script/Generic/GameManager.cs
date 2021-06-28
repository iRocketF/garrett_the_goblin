using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    private int mainMenu = 0;
    private int game = 1;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Game Manager not found, add it to the scene");
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(game);
    }
}
