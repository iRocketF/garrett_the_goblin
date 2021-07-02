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

    public bool isExitOpen = false;
    public bool isWon = false;
    public bool isLost = false;

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

        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && (isWon || isLost))
        {
            ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void LoadGame()
    {
        ResetGame();
        SceneManager.LoadScene(game);
    }

    public void OpenTheExit()
    {
        isExitOpen = true;
    }

    public void FoundTheExit()
    {
        isWon = true;
    }

    public void ResetGame()
    {
        isWon = false;
        isLost = false;
        isExitOpen = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoseGame()
    {
        isLost = true;
    }
}
