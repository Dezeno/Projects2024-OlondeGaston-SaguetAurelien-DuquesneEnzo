using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class MainMenuTests
{
    private GameObject _playButton;
    private GameObject _quitButton;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("Main Menu");
        yield return null; // Wait for the scene to load

        // Find the buttons in the scene
        _playButton = GameObject.Find("Play");
        _quitButton = GameObject.Find("Quit");
    }
    
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator Play()
    {
        // Simulate a click on the Play button
        _playButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(1); // Allow any transitions to occur

        // Check if the active scene is now the Game scene
        Assert.AreEqual("Game", SceneManager.GetActiveScene().name);
    }
    
    [UnityTest]
    public IEnumerator Quit()
    {
        // Simulate a click on the Quit button
        _quitButton.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(2); // Wait for the application to quit

        // Check if the application has quit
        Assert.IsFalse(Application.isPlaying);
    }
}
