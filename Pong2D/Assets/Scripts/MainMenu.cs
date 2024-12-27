using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Charge la scène de jeu.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    
    /// <summary>
    /// Permet de quitter le jeu notamment lorsqu'on appuie sur le bouton quitter.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
