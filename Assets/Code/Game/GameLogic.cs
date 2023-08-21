using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    GameObject[] bricks;

    public TMP_Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");

        if (bricks.Length <= 0 )
        {
            Debug.Log("Winner!");
            winnerText.text = "Winner!";
        }
    }
}
