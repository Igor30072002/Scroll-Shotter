using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueController : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private PauseController pauseController;
    public void Continue()
    {
        foreach (GameObject character in characters)
            character.SetActive(true);
        pauseController.InPause = false;
        hero.SetActive(true);
        gamePanel.SetActive(true);
    }
}
