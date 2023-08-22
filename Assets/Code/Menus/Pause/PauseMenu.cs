using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public TMP_Text item1;
    public TMP_Text item2;

    private int selectedItem;
    private int itemCount = 2;

    
    public GameLogic gameLogic;

    private void Start()
    {
        // Make sure the pause button
        // is hidden when the game
        // starts
        pauseMenu.SetActive(false);

        selectedItem = 1;
        item1.fontStyle = FontStyles.Bold;
    }

    private void Update()
    {
        DetectPauseKeypress();
        MenuNavigation();

        //Debug.Log("Countdown: " + gameLogic.countdownEnabled);
    }

    private void DetectPauseKeypress()
    {
        // if not during countdown: 
        if (!gameLogic.countdownEnabled)
        {
            // Detecting if the player pressed p or escape
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                DoPause();
            }
        }
    }

    private void MenuNavigation()
    {
        Debug.Log("Selected Item: " + selectedItem);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            selectedItem += 1;

            if (selectedItem > itemCount)
            {
                selectedItem = 1;
            }

            item1.fontStyle = FontStyles.Normal;
            item2.fontStyle = FontStyles.Normal;


            switch (selectedItem)
            {
                case 1:
                    item1.fontStyle = FontStyles.Bold;
                    break;
                case 2:
                    item2.fontStyle = FontStyles.Bold;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            selectedItem -= 1;

            if (selectedItem < 1)
            {
                selectedItem = itemCount;
            }

            item1.fontStyle = FontStyles.Normal;
            item2.fontStyle = FontStyles.Normal;


            switch (selectedItem)
            {
                case 1:
                    item1.fontStyle = FontStyles.Bold;
                    break;
                case 2:
                    item2.fontStyle = FontStyles.Bold;
                    break;
            }
        }


        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            switch (selectedItem)
            {
                case 1:
                    OnResumeButton();
                    break;
                case 2:
                    OnQuitButton();
                    break;
            }
        }
    }

    public void OnResumeButton()
    {
        DoPause();
    }

    public void OnQuitButton()
    {
        Debug.Log("Quitting...");

        // Quit to the main menu
        SceneManager.LoadScene(0);
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
