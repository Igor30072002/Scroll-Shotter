using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private Text[] gamePanelIndicators;
    [SerializeField] private Text[] finishIndicators;
    [SerializeField] private GameObject gamePanel;
    private int[] indicators;
    private float[] frequency;
    private float[] timer;
    private bool[] isFinished;
    private int[] intFinishIndicators;

    private void Awake()
    {
        timer = new float[] { 0, 0 };
        isFinished = new bool[] { false, false };
        intFinishIndicators = new int[] { 0, 0 };
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleport3"))
        {
            victoryPanel.SetActive(true);
            indicators = new int[] { int.Parse(gamePanelIndicators[0].text), int.Parse(gamePanelIndicators[1].text) };
            frequency = new float[] { indicators[0] / 2, indicators[1] / 2 };
            for (int i = 0; i < isFinished.Length; i++)
            {
                isFinished[i] = true;
                gamePanel.SetActive(false);
            }
        }
    }  
    
    private void Update()
    {
        for(int i = 0; i < gamePanelIndicators.Length; i++) {
            if (isFinished[i])
            {
                timer[i] += Time.deltaTime;
                if (intFinishIndicators[i] < indicators[i])
                {
                    finishIndicators[i].text = ((int)(timer[i] * frequency[i])).ToString();
                    intFinishIndicators[i] = int.Parse(finishIndicators[i].text);
                }
                else
                {
                    isFinished[i] = false;
                }
            }
        }
    }
}
