using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        // Make sure the pause button
        // is hidden when the game
        // starts
        pauseMenu.SetActive(false);

    }

    private void Update()
    {
        DetectPauseKeypress();
    }

    private void DetectPauseKeypress()
    {
        // Detecting if the player pressed p or escape
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            DoPause();
        }
    }

    public void OnResumeButton()
    {
        DoPause();
    }



    public void OnQuitButton()
    {
        Debug.Log("Quitting...");

        // Quit the game
        Application.Quit(); 
    }


    public void DoPause()
    {
        // timeScale 1 means the game is running
        if (Time.timeScale == 1)
        {
            Debug.Log("Paused");
            // Show the pause menu
            pauseMenu.SetActive(true);

            // Pause the game engine
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("Unpaused");
            // Hide the pause menu
            pauseMenu.SetActive(false);

            // Unpause the game engine
            Time.timeScale = 1;
        }
    }
}
