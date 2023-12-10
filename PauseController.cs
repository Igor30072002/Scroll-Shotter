using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool inPause;
    public bool InPause
    {
        get { return inPause; }
        set { inPause = value; }
    }
    [SerializeField] private GameObject[] characters;
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Shooter heroShooter;

    private void Awake()
    {
        inPause = false;
    }

    public void Pause()
    {
        foreach(GameObject character in characters)
            character.SetActive(false);
        inPause = true;
        hero.SetActive(false);
        gamePanel.SetActive(false);
        heroShooter.CurrentBulletValue++;
    }
}
