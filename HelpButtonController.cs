using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpButtonController : MonoBehaviour
{
    private string helpString;
    private string currentText;
    private float timer;
    private int index;
    private bool buttonClicked;
    public bool ButtonClicked => buttonClicked;
    [SerializeField] private Text helpText;
    private void Start()
    {
        helpString = "Find the button to move the obstacle and enter the teleport";
        timer = 0;
        index = 0;
        buttonClicked = false;
    }

    public void HelpButtonClick()
    {
        buttonClicked = true;
    }

    private void Update()
    {
        if (buttonClicked)
        {
            timer += Time.deltaTime;
            if (timer > 0.03f && index < helpString.Length)
            {
                currentText += helpString[index];
                helpText.text = currentText;
                index++;
                timer = 0;
            }
            else if (timer > 5)
            {
                currentText = "";
                helpText.text = currentText;
                index = 0;
                buttonClicked = false;
            }
        }
    }
}
