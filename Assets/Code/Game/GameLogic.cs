using System;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    GameObject[] bricks;
    GameObject ball;
    GameObject player;
    public GameObject newGamePanel;
    public GameObject gameStartCountdownPanel;
    public TMP_Text gameOverText;
    public TMP_Text winnerText;
    public TMP_Text countdownText;

    private int countdown;

    public bool countdownEnabled;


    private void Start()
    {
        // initialize: 
        countdown = 3;
        countdownEnabled = true;

        // Get the ball and player, 
        // and deactivate them until the 
        // countdown is complete
        ball = GameObject.FindGameObjectWithTag("Ball");
        player = GameObject.FindGameObjectWithTag("Player");
        ball.SetActive(false);
        player.SetActive(false);

        // start the countdown
        StartCoroutine(Countdown(countdown));
    }
    void Update()
    {
        WinDetection();
    }

    private void WinDetection()
    {
        // Fill the bricks array with
        // every brick object
        bricks = GameObject.FindGameObjectsWithTag("Brick");

        // Do we have any bricks left?
        if (bricks.Length <= 0)
        {
            if(newGamePanel != null)
            {
                Debug.Log("Winner!");
                // Display the winner text
                // TODO this should be a 
                // winner menu
                newGamePanel.SetActive(true);
                winnerText.text = "Winner!";
            }
        }
    }
    
    public void GameOver()
    {
        // Display game over text
        // TODO: this should show
        // the gameover menu
        if (newGamePanel != null)
        {
            newGamePanel.SetActive(true);
            gameOverText.text = "Game Over!";
            Debug.Log("Game over!");
        }
    }

    public void OnNewGame()
    {
        Debug.Log("Starting a new game...");
        // Load the GameScene (main game)
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator Countdown(int count)
    {
        // loop until count is 0
        while (count >= 0)
        {
            countdownEnabled = true;
            // If count is zero display GO
            // else display the countdown value
            if (count == 0)
            {
                countdownText.text = "GO!";
            }
            else
            {
                countdownText.text = string.Format("{0}", count);
            }
            // Wait for 1 second
            yield return new WaitForSeconds(1);
            count--;
        }

        // Start the game: 
        ball.SetActive(true);
        player.SetActive(true);

        countdownEnabled = false;

        // Remove the countdown panel
        Destroy(gameStartCountdownPanel);
    }

}
