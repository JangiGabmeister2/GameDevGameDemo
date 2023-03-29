using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When loading and unloading scenes
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private bool canSwitch = false;
    private bool toggle = true;

    private void Awake()
    {
        instance = this;
    }

    public void NextScene()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Load the next scene after the current scene
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
    public void Restart()
    {
        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Load the next scene after current scene
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void Quit()
    {
        // Closes the game
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Menu()
    {
        // We return to the menu
        SceneManager.LoadScene("Menu");
    }

    public void Extra()
    {
        //switches to extra level 1
        SceneManager.LoadScene("Stage G");
    }

    void Update()
    {
        // When the player hits escape
        if (Input.GetKey("escape"))
        {
            // We return to the menu
            SceneManager.LoadScene("Menu");
        }

        if (canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                toggle = !toggle;
            }

            if (toggle)
            {
                player1.GetComponent<Player>().enabled = true;
                player2.GetComponent<Player>().enabled = false;
            }
            else
            {
                player1.GetComponent<Player>().enabled = false;
                player2.GetComponent<Player>().enabled = true;
            }
        }
    }
}
