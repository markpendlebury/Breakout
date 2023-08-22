using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject[] bricks;
    public TMP_Text gameOverText;
    public TMP_Text winnerText;

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
            Debug.Log("Winner!");
            // Display the winner text
            // TODO this should be a 
            // winner menu
            winnerText.text = "Winner!";
        }
    }
    
    public void GameOver()
    {
        // Display game over text
        // TODO: this should show
        // the gameover menu
        gameOverText.text = "Game Over!";
        Debug.Log("Game over!");
    }
}
