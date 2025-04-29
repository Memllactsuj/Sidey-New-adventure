using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image[] message;
    public GameObject mask;
    public GameObject maze;
    private int currentMessageIndex = 0;
    private bool gameStarted = false;

    void Start()
    {
        ShowMessage(currentMessageIndex);
        mask.SetActive(false);
        maze.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!gameStarted)
            {
                if (currentMessageIndex < message.Length - 1)
                {
                    currentMessageIndex++;
                    ShowMessage(currentMessageIndex);
                } else
                {
                    StartGame();
                }
            }
        }
    }

    void ShowMessage(int index)
    {
        foreach (Image msg in message)
        {
            msg.gameObject.SetActive(false);
        }
        message[index].gameObject.SetActive(true);
    }

    void StartGame()
    {
        gameStarted = true;

        foreach (Image msg in message)
        {
            msg.gameObject.SetActive(false);
        }
        mask.SetActive(true);
        maze.SetActive(true);
    }
}
