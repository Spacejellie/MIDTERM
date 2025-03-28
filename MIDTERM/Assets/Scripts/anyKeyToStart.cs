using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class anyKeyToStart : PlayerMovDic
{
    public bool keyPressed = false;
    public TextMeshProUGUI text;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
       // Check for any key press to start the game
        if (!keyPressed && Input.anyKeyDown)
        {
            keyPressed = true; 
            Debug.Log("Game Started!");
            LoadGame(); // Call the method to load the next scene
        }
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Intro"); // Load the scene named "Intro"
    }
}

