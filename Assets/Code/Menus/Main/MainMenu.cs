using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_Text item1;
    public TMP_Text item2;

    private int selectedItem;
    private int itemCount = 2;

    private void Start()
    {
        selectedItem = 1;
        item1.fontStyle = FontStyles.Bold;
    }

    private void Update()
    {
        MenuNavigation();

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
                    OnNewGameButton();
                    break;
                case 2:
                    OnQuitButton();
                    break;
            }
        }
    }

    public void OnNewGameButton()
    {
        Debug.Log("Starting a New Game...");
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
