using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// When loading and unloading scenes
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Tooltip("For each player in the scene. (2 max)")]
    [SerializeField] private GameObject[] players;
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

    public void End()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Extra()
    {
        //switches to extra level 1
        SceneManager.LoadScene("Stage G");
    }

    private void SwitchPlayers()
    {
        if (canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                toggle = !toggle;
            }

            if (toggle)
            {
                players[0].GetComponent<Player>().enabled = true;
                players[1].GetComponent<Player>().enabled = false;
            }
            else
            {
                players[0].GetComponent<Player>().enabled = false;
                players[1].GetComponent<Player>().enabled = true;
            }
        }
    }

    void Update()
    {
        // When the player hits escape
        if (Input.GetKey("escape"))
        {
            // We return to the menu
            SceneManager.LoadScene("Menu");
        }

        //when the player hits R key
        if (Input.GetKey(KeyCode.R))
        {
            //resets the level
            Restart();
        }

        if (players.Length > 1)
        {
            SwitchPlayers();
        }
    }
}
